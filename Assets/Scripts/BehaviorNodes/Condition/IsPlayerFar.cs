using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//条件节点(判断玩家的距离是否在一定范围内)
public class IsPlayerFar : EnemyAction
{
    [SerializeField] public float range=5;
    protected override State OnUpdate() {
        return Mathf.Abs(context.transform.position.x - target.transform.position.x) < range ? State.Success : State.Failure;
    }
}
