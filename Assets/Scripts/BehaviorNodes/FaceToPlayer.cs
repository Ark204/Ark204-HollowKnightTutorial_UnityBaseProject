using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FaceToPlayer : EnemyAction
{
    [SerializeField][Range(-1,1)] int baseFace=1;//��ʼ����(Ĭ�ϳ��� Ϊ1)
    protected override void OnStart() {
        base.OnStart();
        if (target.position.x - context.transform.position.x > 0) //>0 �ұ� <0 ��
            context.transform.localScale =new Vector3(baseFace,context.transform.localScale.y,context.transform.localScale.z);
        else context.transform.localScale = new Vector3(-baseFace, context.transform.localScale.y, context.transform.localScale.z);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
