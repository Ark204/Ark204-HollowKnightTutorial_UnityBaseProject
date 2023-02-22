using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�����ڵ�(�ж��Ƿ�����ҽ��н���)
public class IsInteract : EnemyAction
{
    [SerializeField] public float range = 5;
    protected override State OnUpdate() {
        //�жϾ���
        if (target == null) return State.Success;
        if(Vector2.Distance(context.transform.position, target.transform.position) < range&& Input.GetKeyUp(KeyCode.G))
            return State.Failure;
        else return State.Success;
    }
    public override void OnDrawGizmos()
    {
        //���ƽ�����Χ
        Gizmos.DrawWireSphere(context.transform.position, range);
    }
}
