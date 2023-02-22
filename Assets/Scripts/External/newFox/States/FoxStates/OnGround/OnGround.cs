using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //�������״̬ʱ����������Ծ����
        m_fox.jumpCount = 2;
    }
    public override void update()
    {
        base.update();
        GroundJump();
        Grouch();
        GroundFall();
    }
    //������Ծ
    protected void GroundJump()
    {
        //����кϷ���Ծ����
        if(m_fox.jumpPressed)
        {
            //�л�Ϊ��Ծ״̬
            //m_animator.SetBool("running", false);
            m_stateController.ChangeState(FoxState.up);
            m_fox.jumpPressed = false;
        }
    }
    protected void GroundFall()
    {
        //����ӵ�������
        if(m_rigidbody2D.velocity.y<-0.1)
        {
            //�л�Ϊ����״̬
            m_stateController.ChangeState(FoxState.down);
        }
    }
    protected void Grouch()
    {
        if(m_fox.grouchPressed)
        {

            //�л�Ϊſ��״̬
            m_stateController.ChangeState(FoxState.grouch);
        }
    }
}
