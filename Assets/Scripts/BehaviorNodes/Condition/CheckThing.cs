using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//用于检查角色背包是否有某样物品
public class CheckThing : ActionNode
{
    [SerializeField] Bag bag;//背包引用
    [SerializeField] ItemInfo info;//物品信息
    [SerializeField] int count=1;//数量
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        return bag.FindItem(info) >= count? State.Success:State.Failure;
    }
    protected override void OnStop() { }
}
