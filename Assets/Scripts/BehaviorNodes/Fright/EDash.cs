using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EDash : EnemyAction
{
    [SerializeField] [Range(-1, 1)] int baseFace;
    [SerializeField] float speed;
    [SerializeField] [Range(0,10)] float time;//最长冲刺时间
    [SerializeField] bool followYAxis=false;
    [SerializeField] float stopDistanceFromWall;//距离墙多远时候停下

    Rigidbody2D body;
    float m_gravity;
    float startTime;
    protected override void OnStart()
    {
        base.OnStart();
        startTime = Time.time;
        body=context.gameObject.GetComponent<Rigidbody2D>();
        m_gravity = body.gravityScale;
        body.gravityScale = 0;//移除重力
        if (!followYAxis) body.velocity = new Vector3(speed * context.transform.localScale.x * baseFace, body.velocity.y);
        else
        {
            Vector2 direct = context.transform.position - target.transform.position;//计算方向向量
            body.velocity = direct * speed;
        }
    }
    protected override State OnUpdate()
    {
        if (Time.time - startTime > time)
        {
            body.velocity = new Vector3(0, body.velocity.y);
            body.gravityScale = m_gravity;//还原重力
            return State.Success;
        }
        return State.Running;
    }
}
