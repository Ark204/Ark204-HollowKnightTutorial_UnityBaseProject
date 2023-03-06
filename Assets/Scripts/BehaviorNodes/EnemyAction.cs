using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public abstract class EnemyAction : ActionNode
{
    [SerializeField]protected RangeTarget range;
    protected override void OnStart()
    {
        range = context.gameObject.GetComponentInChildren<RangeTarget>();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
