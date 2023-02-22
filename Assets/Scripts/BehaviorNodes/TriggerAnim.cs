using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TriggerAnim : ActionNode
{
    [SerializeField] string animString;
    protected override void OnStart() {
        context.animator.SetTrigger(animString);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
