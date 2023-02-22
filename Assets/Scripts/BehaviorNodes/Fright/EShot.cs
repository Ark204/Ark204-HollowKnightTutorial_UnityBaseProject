using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EShot : ActionNode
{
    [SerializeField]Object bullet;
    [SerializeField] [Range(-1, 1)] int baseFace;
    [SerializeField] Vector3 offset;
    [SerializeField] Vector3 force;
    protected override void OnStart() {
        float direct = context.transform.localScale.x * baseFace;
        Vector3 childPos =context.transform.position + new Vector3(offset.x * direct, offset.y, offset.z);//计算子物体的坐标
        var effect = (GameObject)Instantiate(bullet, childPos, Quaternion.identity);//加载预制体
        effect.transform.localScale = new Vector3(effect.transform.localScale.x * direct, effect.transform.localScale.y, effect.transform.localScale.z);
        effect.GetComponent<Rigidbody2D>().AddForce(new Vector2(force.x*direct, force.y));
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
