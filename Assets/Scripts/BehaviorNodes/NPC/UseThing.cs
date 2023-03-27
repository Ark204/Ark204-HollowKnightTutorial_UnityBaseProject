using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//物品增加、减少
public class UseThing : ActionNode
{
    [SerializeField] Bag bag;//背包引用
    [SerializeField] ItemInfo info;//物品信息
    [SerializeField] int count = -1;//数量(大于0则增加，小于0则减少)
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        if (count >= 0)//增加
        {
            bag.AddItem(info, (uint)count);//增加物品
            return State.Success;
        }
        else
        {
            return bag.SubItem(info, (uint)(-count)) ? State.Success : State.Failure;//尝试消耗物品，返回函数执行返回值
        }
    }
    protected override void OnStop() { }
}
