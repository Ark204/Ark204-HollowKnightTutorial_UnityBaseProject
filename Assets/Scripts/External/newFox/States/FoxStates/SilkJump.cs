using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkJump : FoxState
{
    public override void enter(StateController stateController)
    {
        base.enter(stateController);
        m_animator.Play("somersault");
    }
    public override void update()
    {
        
    }
    public override void exit()
    {
        
    }
}
