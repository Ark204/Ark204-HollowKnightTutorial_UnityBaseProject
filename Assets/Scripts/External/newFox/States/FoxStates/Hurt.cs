using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //����hurt����
        m_animator.Play("hurt");
    }
    public override void update()
    {
        //���ٵ��û�����ƶ��Լ����
    }
    public override void exit()
    {
        
    }
}
