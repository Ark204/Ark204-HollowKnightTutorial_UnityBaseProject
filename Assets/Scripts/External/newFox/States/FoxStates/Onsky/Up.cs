using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : Onsky
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //动画切换为jumping
        m_animator.Play("jump");
        //跳跃次数减一
        m_fox.jumpCount--;
        //跳跃
        m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x,m_fox.jumpforce);
    }
    public override void update()
    {
        //基本移动
        base.update();
        //如果竖直方向速度小于0
        if(m_rigidbody2D.velocity.y<0)
        {
            //切换为下落状态
            m_stateController.ChangeState(FoxState.down);
        }
    }
}
