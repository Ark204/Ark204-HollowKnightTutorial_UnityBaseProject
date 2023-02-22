using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onsky : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
    }
    public override void update()
    {
        base.update();
        if (m_fox.jumpPressed && m_fox.jumpCount > 0)
        {
            //���������Ծ״̬
            m_stateController.ChangeState(FoxState.up);
            m_fox.jumpPressed = false;
        }
    }
}
