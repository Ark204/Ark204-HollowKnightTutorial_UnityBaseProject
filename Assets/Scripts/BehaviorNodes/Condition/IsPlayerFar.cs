using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�����ڵ�(�ж���ҵľ����Ƿ���һ����Χ��)
public class IsPlayerFar : EnemyAction
{
    [SerializeField] public float m_range=5;
    protected override State OnUpdate() {
        try
        {
            return Mathf.Abs(context.transform.position.x - range.target.transform.position.x) < m_range ? State.Success : State.Failure;
        }
        catch { return State.Failure; }
    }
}
