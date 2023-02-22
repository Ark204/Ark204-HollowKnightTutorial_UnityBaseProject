using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxState : IState
{
    [SerializeField] float shutSpeed=10;
    //static Fox's states
    public static Idle idle = new Idle();
    public static Run run= new Run();
    public static Up up= new Up();
    public static Down down= new Down();
    public static Grouch grouch = new Grouch();
    public static Climb climb = new Climb();
    public static Hurt hurt = new Hurt();
    public static SilkJump silkJump = new SilkJump();

    //components
    protected Animator m_animator;
    protected Rigidbody2D m_rigidbody2D;
    protected Fox m_fox;
    protected Transform m_transform;
    //���Ƴ���ű��е�start
    public override void enter(StateController stateController)
    {
        //�����ȡ
        base.enter(stateController);
        m_animator = m_stateController.GetComponent<Animator>();
        m_rigidbody2D = m_stateController.GetComponent<Rigidbody2D>();
        m_fox = m_stateController.GetComponent<Fox>();
        m_transform = m_stateController.GetComponent<Transform>();
    }
    public override void update()
    {
        //�ƶ��������
        MoveMent();
        Shut();
        Silk();
        Climb();
    }
    //ͨ���ƶ�����
    protected void MoveMent()
    {
        float horizontalmove = Input.GetAxisRaw("Horizontal");
        float speed = m_fox.speed;
        m_rigidbody2D.velocity = new Vector2(horizontalmove * speed, m_rigidbody2D.velocity.y);
        if(horizontalmove!=0)
        {
            m_transform.localScale = new Vector3(horizontalmove, 1, 1);
        }
    }
    protected void Climb()
    {
        //������¡���/�¡���������������Χ
        if (m_fox.climbPressed&&m_fox.inLadder)
        {
            //��ֹ���汻�л�Ϊſ��״̬
            m_fox.grouchPressed = false;
            //�л�Ϊclimb״̬
            m_stateController.ChangeState(FoxState.climb);
        }
    }
    //ͨ���������
    protected virtual void Shut()
    {
        //����������
        if (m_fox.shutPressed)
        {
            GameObject bullet = m_stateController.LoadPrefabs("Prefabs/Bullet");
            //��ʼ��Ԥ���������
            Vector2 silkStart = m_fox.silkStart.position;
            bullet.transform.position = new Vector2(silkStart.x + m_transform.localScale.x, silkStart.y);
            //���㷽������
            Vector3 vector3 = new Vector3(m_fox.shutPoint.x - m_transform.position.x, m_fox.shutPoint.y - m_transform.position.y, 0);
            vector3.Normalize();
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shutSpeed * vector3;
            m_fox.shutPressed = false;
        }
    }
    protected virtual void Silk()
    {
        //���������֩��˿
        if (m_fox.silkPressed)
        {
            GameObject Silk;
            if (Input.GetKey(KeyCode.W))
            {
                Silk= m_stateController.LoadPrefabs("Prefabs/silk");//����֩��˿Ԥ����
            }
            else
            {
                Silk = m_stateController.LoadPrefabs("Prefabs/SilkAttack");//������
            }
            //��ʼ��Ԥ���������
            Vector2 silkStart = m_fox.silkStart.position;
            Silk.transform.position = new Vector2(silkStart.x + 1, silkStart.y);
            //���÷����Ϊ������
            Silk.transform.SetParent(m_fox.silkStart);
            //Silk.GetComponent<Silk>().m_transform = m_fox.silkStart;
            //���㷽������
            Vector3 vector3 = new Vector3(m_fox.shutPoint.x - m_transform.position.x, m_fox.shutPoint.y - m_transform.position.y, 0);
            vector3.Normalize();
            Vector3 horizontal = new Vector3(1, 0, 0);
            //������ת�Ƕ�
            float degree = Vector3.Angle(horizontal, vector3);
            //����ǵ�����
            degree *= (m_fox.shutPoint.y - m_transform.position.y) / Mathf.Abs(m_fox.shutPoint.y - m_transform.position.y);
            //��ת�����
            m_fox.silkStart.transform.Rotate(0, 0, m_transform.localScale.x * degree);
            m_fox.silkPressed = false;
        }
    }
}
