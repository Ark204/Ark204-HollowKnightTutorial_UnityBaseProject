using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//2ά����ĳ��
public class EDash2D : EnemyAction
{
    [SerializeField] Vector2 dir;//��̷���
    [SerializeField] float speed;
    [SerializeField] [Range(0, 10)] float time;//����ʱ��

    float startTime;
    protected override void OnStart()
    {
        //base.OnStart();
        //startTime = Time.time;
        //body = context.gameObject.GetComponent<Rigidbody2D>();
        //m_gravity = body.gravityScale;
        //body.gravityScale = 0;//�Ƴ�����
        //if (!followYAxis) body.velocity = new Vector3(speed * context.transform.localScale.x * baseFace, body.velocity.y);
        //else
        //{
        //    Vector2 direct = context.transform.position - range.target.transform.position;//���㷽������
        //    body.velocity = direct * speed;
        //}
    }
}
