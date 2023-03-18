using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//血量检测
public class EStiff : ActionNode
{
    [SerializeField] [Range(0, 1)] List<float> points;//检测点
    [SerializeField] int curr=0;//当前触发点
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        if (curr + 1 > points.Count) return State.Failure;//超越数组=已经没有监测点了->返回Failure
        if ((float)context.destructable.CurrentHealth / (float)context.destructable.health <= points[curr])
        {
            curr++;//移至下个触发点
            return State.Success;//低于血限，返回Succeed
        }
        else return State.Failure;//仍高于血限，返回Failure
    }
    protected override void OnStop() { }
}
