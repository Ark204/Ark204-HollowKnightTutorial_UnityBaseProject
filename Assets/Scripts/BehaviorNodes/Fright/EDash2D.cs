using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//2维方向的冲刺
public class EDash2D : EnemyAction
{
    [SerializeField] Vector2 dir;//冲刺方向
    [SerializeField] float speed;
    [SerializeField] [Range(0, 10)] float time;//最长冲刺时间

    float startTime;
    protected override void OnStart()
    {
        //base.OnStart();
        //startTime = Time.time;
        //body = context.gameObject.GetComponent<Rigidbody2D>();
        //m_gravity = body.gravityScale;
        //body.gravityScale = 0;//移除重力
        //if (!followYAxis) body.velocity = new Vector3(speed * context.transform.localScale.x * baseFace, body.velocity.y);
        //else
        //{
        //    Vector2 direct = context.transform.position - range.target.transform.position;//计算方向向量
        //    body.velocity = direct * speed;
        //}
    }
}
