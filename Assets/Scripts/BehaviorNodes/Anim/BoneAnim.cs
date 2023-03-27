using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//用于播放骨骼动画
public class BoneAnim : ActionNode
{
    [SerializeField] string animString;//想播放的动画名
    protected override void OnStart() { }

    protected override State OnUpdate()
    {
        context.armatureComponent.animation.Play(animString);//播放骨骼动画
        return State.Success;
    }

    protected override void OnStop() { }
}
