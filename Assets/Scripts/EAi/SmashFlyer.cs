using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ҵ�ʷ��ķ
public class SmashFlyer : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D m_rigidbody2D;
    [System.NonSerialized] public EnemyBase enemyBase;
    [SerializeField] RangeTarget getPlayer;//�ṩ��Χ�ڼ��Ŀ��
    //[SerializeField] DestoryTri selfTrigger;//������ײ������
    private Transform lookAtTarget; //If I'm a bomb, I will point to a transform, like the player

    [Header("Ground Avoidance")]
    [SerializeField] private float rayCastWidth = 5;
    [SerializeField] private float rayCastOffsetY = 1;
    [SerializeField] private LayerMask layerMask; //What will I be looking to avoid?
    private RaycastHit2D rayCastHit;

    [Header("Flight")]
    [SerializeField] private bool avoidGround; //Should I steer away from the ground?
    private Vector3 distanceFromPlayer;
    [SerializeField] private float maxSpeedDeviation;
    [SerializeField] private float easing = 1; //How intense should we ease when changing speed? The higher the number, the less air control!
    
    public float attentionRange; //How far can I see?
    public float lifeSpan; //Keep at zero if you don't want to explode after a certain period of time.
    [System.NonSerialized] public float lifeSpanCounter;
    private bool sawPlayer = false; //Have I seen the player?
    [SerializeField] private float speedMultiplier;
    [System.NonSerialized] public Vector3 speed;
    [System.NonSerialized] public Vector3 speedEased;
    [SerializeField] private bool smashing=false;//�Ƿ����ҵ�״̬
    [SerializeField] private Vector2 targetOffset = new Vector2(0, 2);
    //LandCheck
    private float bombCounter = 0;//����ʣ����ȴʱ��(ʵʱ)
    [SerializeField] private float bombCounterMax = 5; //(��CDʱ��)How many seconds before shooting another bomb?
    [SerializeField] float gravity=1f;//�ҵ�ʱ�����߶�
    [SerializeField] float bottomOffset;//�ײ���ƫ��
    [SerializeField] LayerMask  combatLayerMask;//����Ĳ㼶
    private readonly Collider2D[] currentColliders = new Collider2D[5];
    private int currentColliderHits;//���ؼ����

    // Use this for initialization
    void Start()
    {
        enemyBase = GetComponent<EnemyBase>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        getPlayer.onTargetEnter += OnTargetEnter;
        getPlayer.onTargetExit += OnTargetExit;

        //selfTrigger.onDestory += () => { enemyBase.Die(); };
        //if (enemyBase.isBomb)
        //{
        //    lookAtTarget = NewPlayer.Instance.gameObject.transform;//TODO:GetPlayerTransform as target
        //}

        speedMultiplier += Random.Range(-maxSpeedDeviation, maxSpeedDeviation);
    }

    private void OnTargetEnter(Collider2D obj)
    {
        lookAtTarget = obj.transform;
    }

    private void OnTargetExit(Collider2D obj)
    {
        if (lookAtTarget == obj.transform) lookAtTarget = null;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position indicating the attentionRange
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attentionRange);
    }

    // Update is called once per frame
    void Update()
    {
        //��������
        if (smashing)
        {
            HandleCollisions();//��ؼ��
            return;//����
        }
        //���������AI
        //caculate distance from player
        if (!lookAtTarget) return;//������ǲ�����Ұ�ڣ��򷵻�
        distanceFromPlayer.x = (lookAtTarget.position.x + targetOffset.x) - transform.position.x;
        distanceFromPlayer.y = (lookAtTarget.position.y + targetOffset.y) - transform.position.y;
        speedEased += (speed - speedEased) * Time.deltaTime * easing;
        transform.position += speedEased * Time.deltaTime;//�����Ƿ����ƶ�

        if (lookAtTarget != null || Mathf.Abs(distanceFromPlayer.x) <= attentionRange && Mathf.Abs(distanceFromPlayer.y) <= attentionRange)
        {
            sawPlayer = true;
            speed.x = (Mathf.Abs(distanceFromPlayer.x) / distanceFromPlayer.x) * speedMultiplier;
            speed.y = (Mathf.Abs(distanceFromPlayer.y) / distanceFromPlayer.y) * speedMultiplier;

            if (true/*!NewPlayer.Instance.frozen*/)//TODO: frozen
            {
                //�ҵ�
                if (bombCounter > bombCounterMax)
                {
                    smashing = true;//��������״̬
                    //m_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;//�ָ�����״̬
                    m_rigidbody2D.velocity = Vector2.zero;//ȡ���ٶ�
                    m_rigidbody2D.gravityScale = gravity;//���������߶�
                    bombCounter = 0;
                }
                else bombCounter += Time.deltaTime;
                //if (shootsBomb)
                //{
                //    if (bombCounter > bombCounterMax)
                //    {
                //        ShootBomb();
                //        bombCounter = 0;
                //    }
                //    else
                //    {
                //        bombCounter += Time.deltaTime;
                //    }
                //}
            }
            //else
            //{
            //    speedEased = Vector3.zero;
            //}
        }
        else
        {
            speed = Vector2.zero;
            if (transform.position.y > (lookAtTarget.position.y + targetOffset.y) && sawPlayer)
            {
                speed = new Vector2(0f, -.05f);
            }

        }

        // Check for walls and ground
        if (avoidGround)
        {
            rayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.right, rayCastWidth, layerMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.right * rayCastWidth, Color.yellow);

            if (rayCastHit.collider != null)
            {
                speed.x = -(Mathf.Abs(speed.x));

            }

            rayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.left, rayCastWidth, layerMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.left * rayCastWidth, Color.blue);

            if (rayCastHit.collider != null)
            {
                speed.x = Mathf.Abs(speed.x);

            }

            rayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.down, rayCastWidth, layerMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffsetY), Vector2.down * rayCastWidth, Color.red);

            if (rayCastHit.collider != null)
            {
                speed.y = Mathf.Abs(speed.x);

            }
        }

        if (lookAtTarget != null)
        {
            LookAt2D();
        }

        if (lifeSpan != 0)
        {
            if (lifeSpanCounter < lifeSpan)
            {
                lifeSpanCounter += Time.deltaTime;
            }
            else
            {
                enemyBase.Die();
            }
        }
    }
    //��ת
    void LookAt2D()
    {
        float angle = Mathf.Atan2(speedEased.y, speedEased.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    //����Ƿ����
    private void HandleCollisions()
    {
        //bool wasOnGround = isOnGround;
        //isOnGround = false;
        //if (smashing == false) return;//��������״̬������
        //���
        var bottom = transform.position - new Vector3(0, bottomOffset, 0);
        currentColliderHits = Physics2D.OverlapBoxNonAlloc(bottom,
            new Vector2(0.24f, 0.2f), 0, currentColliders, layerMask);
        //Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(bottomTransform.position, new Vector2(0.24f, 0.2f), 0, combatLayerMask);
        //bool haveCollision = false;
        //foreach (var coll in collider2Ds)
        //{
        //    Debug.Log(coll.gameObject.layer);
        //    if (!coll.isTrigger)//��ײ�����зǴ�����
        //    {
        //        haveCollision = true; break;
        //    }
        //}
        if (/*haveCollision*/currentColliderHits > 0)//����⵽������->�Ѿ����
        {
            smashing = false;//��������
            m_rigidbody2D.gravityScale = 0;
            //m_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;//ȡ������״̬
        }

        //Animator
        //if (wasOnGround && !isOnGround)
        //{
        //    // Dropping off ledge
        //    animator.SetBool(CharacterAnimations.IsJumping, true);
        //    animator.SetTrigger(CharacterAnimations.StartJump);
        //    //runningDustParticles.gameObject.SetActive(false);
        //}
    }
}
