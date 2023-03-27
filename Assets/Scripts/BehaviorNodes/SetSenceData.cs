using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//设置场景数据的值
public class SetSenceData : ActionNode
{
    [SerializeField] SaveData sceneData;//场景数据
    [SerializeField] bool target = true;//要设置的目标列表，默认为true->持久保存型号
    [SerializeField] int index = 0;//索引
    [SerializeField] bool value=true;//要设置的值，默认为true
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        sceneData.SetBool(index, value, target);//设置数值
        return State.Success;
    }
}
