using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EDash : EnemyAction
{
    [SerializeField] Vector2 dire=Vector2.right;//冲刺方向
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
        m_gravity = body.gravityScale;//保存重力
        body.gravityScale = 0;//移除重力
        Vector2 direct;
        if (!followYAxis)//固定方向 
        {
            float face = context.transform.localScale.x;//读取当前朝向
            direct = new Vector2(dire.x * face / Mathf.Abs(face),dire.y);//计算方向向量
        }
        else
        {
            direct = context.transform.position - range.target.transform.position;//计算方向向量
        }
        body.velocity = direct.normalized * speed;//单位化方向向量*速度
    }
    protected override State OnUpdate()
    {
        if (Time.time - startTime > time) return State.Success;
        return State.Running;
    }
    protected override void OnStop()
    {
        body.velocity = new Vector3(0, 0);//速度还原
        body.gravityScale = m_gravity;//还原重力
    }
}
