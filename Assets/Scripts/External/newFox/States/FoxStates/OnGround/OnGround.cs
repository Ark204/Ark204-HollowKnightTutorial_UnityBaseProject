using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //进入地面状态时重新设置跳跃次数
        m_fox.jumpCount = 2;
    }
    public override void update()
    {
        base.update();
        GroundJump();
        Grouch();
        GroundFall();
    }
    //地上跳跃
    protected void GroundJump()
    {
        //如果有合法跳跃输入
        if(m_fox.jumpPressed)
        {
            //切换为跳跃状态
            //m_animator.SetBool("running", false);
            m_stateController.ChangeState(FoxState.up);
            m_fox.jumpPressed = false;
        }
    }
    protected void GroundFall()
    {
        //如果从地面落下
        if(m_rigidbody2D.velocity.y<-0.1)
        {
            //切换为下落状态
            m_stateController.ChangeState(FoxState.down);
        }
    }
    protected void Grouch()
    {
        if(m_fox.grouchPressed)
        {

            //切换为趴下状态
            m_stateController.ChangeState(FoxState.grouch);
        }
    }
}
