using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class PlayAnim : ActionNode
{
    [SerializeField] string animString;//想播放的动画名
    protected override void OnStart() { }

    protected override State OnUpdate()
    {
        context.animator.Play(animString);
        return State.Success;
    }

    protected override void OnStop() { }
}
