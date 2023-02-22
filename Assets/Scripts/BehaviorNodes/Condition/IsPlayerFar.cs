using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�����ڵ�(�ж���ҵľ����Ƿ���һ����Χ��)
public class IsPlayerFar : EnemyAction
{
    [SerializeField] public float range=5;
    protected override State OnUpdate() {
        return Mathf.Abs(context.transform.position.x - target.transform.position.x) < range ? State.Success : State.Failure;
    }
}
