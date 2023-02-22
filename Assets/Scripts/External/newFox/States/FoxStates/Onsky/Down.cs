using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : Onsky
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //�����л���down
        m_animator.Play("fall");
    }
    public override void update()
    {
        base.update();
        //�����ֱ�����ٶȵ���0
        if (m_rigidbody2D.velocity.y == 0)
        {
            //�л�Ϊվ��״̬
            m_stateController.ChangeState(FoxState.idle);
        }
    }
}
