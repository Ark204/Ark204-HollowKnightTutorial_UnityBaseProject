using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//条件节点(判断是否与玩家进行交互)
public class IsInteract : EnemyAction
{
    static string keyName = "upKey";//键名，默认为空->入触型

    [SerializeField] public float m_range = 5;
    protected override State OnUpdate() {
        //判断距离
        if (range.target == null) return State.Success;
        if (Vector2.Distance(context.transform.position, range.target.transform.position) < m_range
            && Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
            return State.Failure;
        else return State.Success;
    }
    public override void OnDrawGizmos()
    {
        //绘制交互范围
        Gizmos.DrawWireSphere(context.transform.position, m_range);
    }
}
