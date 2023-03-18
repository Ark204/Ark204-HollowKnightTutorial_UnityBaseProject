using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//判断是否受伤
public class CheckGetHurt : ActionNode
{
    [SerializeField] int times;//判断被攻击的次数
    bool m_getHit = false;
    void GetHit(Vector2 force,Vector2 dir,float damage)
    {
        m_getHit = true;
    }
    protected override void OnStart()
    {
        m_getHit = false;//重置受击标志位
        context.destructable.OnHit += GetHit;//添加受击监听
    }
    protected override State OnUpdate()
    {
        return m_getHit ? State.Success : State.Running;
    }
    protected override void OnStop() 
    {
        context.destructable.OnHit -= GetHit;//移除受击监听
    }
}
