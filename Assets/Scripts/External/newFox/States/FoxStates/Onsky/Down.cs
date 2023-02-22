using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Onsky
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //动画切换回down
        m_animator.Play("fall");
    }
    public override void update()
    {
        base.update();
        //如果竖直方向速度等于0
        if (m_rigidbody2D.velocity.y == 0)
        {
            //切换为站立状态
            m_stateController.ChangeState(FoxState.idle);
        }
    }
}
