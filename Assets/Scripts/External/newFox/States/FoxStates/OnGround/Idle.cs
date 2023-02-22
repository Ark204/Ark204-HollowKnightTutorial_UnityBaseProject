using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : OnGround
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        m_animator.Play("idle");
    }
    public override void update()
    {
        base.update();
        //���ˮƽ�����ٶȴ���0
        if(Mathf.Abs(m_rigidbody2D.velocity.x)>0.2)
        {
            //�л�Ϊrun״̬
            m_stateController.ChangeState(FoxState.run);
        }
    }
}
