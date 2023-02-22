using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : OnGround
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //�����л�Ϊrunning
        m_animator.Play("run");
    }
    public override void update()
    {
        base.update();
        //���ˮƽ�ٶ�С��0.1
        if(Mathf.Abs(m_rigidbody2D.velocity.x)<0.2)
        {
            //�л�Ϊidle״̬
            m_stateController.ChangeState(FoxState.idle);
        }
    }
}
