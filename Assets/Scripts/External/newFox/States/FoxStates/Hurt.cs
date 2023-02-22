using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        //播放hurt动画
        m_animator.Play("hurt");
    }
    public override void update()
    {
        //不再调用基类的移动以及射击
    }
    public override void exit()
    {
        
    }
}
