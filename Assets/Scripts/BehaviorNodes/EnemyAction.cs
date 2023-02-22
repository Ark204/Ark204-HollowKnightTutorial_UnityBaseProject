using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public abstract class EnemyAction : ActionNode
{
    [SerializeField]protected Transform target;
    protected override void OnStart()
    {
        target = context.gameObject.GetComponentInChildren<RangeTarget>().target;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        return State.Success;
    }
}
