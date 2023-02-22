using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silk : MonoBehaviour
{
    public float Maxlength = 5;
    public float growspeed = 0.36f;
    public float pullforce = 50f;
    public bool touch = false;
    public Transform m_transform;
    public LayerMask envir;
    public LayerMask ground;
    [SerializeField] float distance=2;
    // Start is called before the first frame update
    void Start()
    {
        //m_transformΪ�����
        m_transform = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (m_transform.localScale.x < Maxlength&&!touch)
        {
            m_transform.localScale = new Vector3(m_transform.localScale.x + growspeed, m_transform.localScale.y , m_transform.localScale.z);
        }
        else
        {
            //��ԭ�����
            m_transform.rotation = new Quaternion();
            m_transform.localScale = new Vector3(1, 1, 1);
            //����˿��
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (m_transform!=null&&((1<<collision.gameObject.layer) & envir)!=0)
        {
            //��ȡ���е�
            Vector3 hitPoint = collision.bounds.ClosestPoint(transform.position);
            //��ȡ��ɫ��
            Vector3 playerPoint = m_transform.parent.position;
            //�������
            Vector2 direction = new Vector2(hitPoint.x - playerPoint.x, hitPoint.y - playerPoint.y);
            //����λ��
            direction.Normalize();
            m_transform.parent.GetComponent<StateController>().ChangeState(FoxState.silkJump);
            m_transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * pullforce, direction.y * pullforce);
            touch = true;
        }
        else if(m_transform != null && ((1<<collision.gameObject.layer) & ground) != 0)//˲��
        {
            //��ȡ���е�
            Vector3 hitPoint = collision.bounds.ClosestPoint(transform.position);
            //��ȡ��ɫ��
            Vector3 playerPoint = m_transform.parent.position;
            //�������
            Vector2 direction = new Vector2(hitPoint.x - playerPoint.x, hitPoint.y - playerPoint.y);
            //����λ��
            direction.Normalize();
            m_transform.parent.position = hitPoint + (Vector3)direction*distance;
            touch = true;
        }
        else if (collision.gameObject.layer == 11) { Destroy(collision.gameObject); }
    }

}
