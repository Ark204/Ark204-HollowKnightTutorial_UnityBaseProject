using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class FaceToPlayer : EnemyAction
{
    [SerializeField][Range(-1,1)] int baseFace=1;//初始朝向(默认朝右 为1)

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        try
        {
            if (range.target.position.x - context.transform.position.x > 0) //>0 右边 <0 左
                context.transform.localScale = new Vector3(baseFace* Mathf.Abs(context.transform.localScale.x), context.transform.localScale.y, context.transform.localScale.z);
            else context.transform.localScale = new Vector3(-baseFace * Mathf.Abs(context.transform.localScale.x), context.transform.localScale.y, context.transform.localScale.z);
            return State.Success;
        }
        catch { return State.Failure; }
    }
}
