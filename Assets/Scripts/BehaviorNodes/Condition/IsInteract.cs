using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�����ڵ�(�ж��Ƿ�����ҽ��н���)
public class IsInteract : EnemyAction
{
    static string keyName = "upKey";//������Ĭ��Ϊ��->�봥��

    [SerializeField] public float m_range = 5;
    protected override State OnUpdate() {
        //�жϾ���
        if (range.target == null) return State.Success;
        if (Vector2.Distance(context.transform.position, range.target.transform.position) < m_range
            && Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
            return State.Failure;
        else return State.Success;
    }
    public override void OnDrawGizmos()
    {
        //���ƽ�����Χ
        Gizmos.DrawWireSphere(context.transform.position, m_range);
    }
}
