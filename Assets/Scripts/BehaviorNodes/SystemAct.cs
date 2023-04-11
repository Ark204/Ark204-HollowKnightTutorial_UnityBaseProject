using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

public class SystemAct : ActionNode
{
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        SceneUtil.Instance.Ending();
        return State.Success;
    }
    protected override void OnStop() { }
}
