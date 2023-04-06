using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//用于播放骨骼动画
public class BoneAnim : ActionNode
{
    [SerializeField] string animString;//想播放的动画名
    [SerializeField] int times=-1;//播放次数
    [SerializeField] [Range(0,100)]float speed=1f;//播放倍速
    protected override void OnStart() { }

    protected override State OnUpdate()
    {
        context.armatureComponent.animation.Play(animString,times);//播放骨骼动画
        //Debug.Log(context.armatureComponent.animation.animationConfig.animation.Length + "  :" + context.armatureComponent.animation.animationConfig.name);
        context.armatureComponent.animation.timeScale = speed;//设置动画速度
        
        return State.Success;
    }

    protected override void OnStop() { }
}
