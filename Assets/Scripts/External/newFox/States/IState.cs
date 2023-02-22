using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[System.Serializable]
public class IState 
{
    protected StateController m_stateController;
    public virtual void update()
    {

    }
    public virtual void enter(StateController stateController)
    {
        //start
        m_stateController = stateController;
    }
    public virtual void exit()
    { }
}
