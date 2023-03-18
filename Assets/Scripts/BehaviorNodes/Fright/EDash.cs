using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EDash : EnemyAction
{
    [SerializeField] Vector2 dire=Vector2.right;//��̷���
    [SerializeField] float speed;
    [SerializeField] [Range(0,10)] float time;//����ʱ��
    [SerializeField] bool followYAxis=false;
    [SerializeField] float stopDistanceFromWall;//����ǽ��Զʱ��ͣ��

    Rigidbody2D body;
    float m_gravity;
    float startTime;
    protected override void OnStart()
    {
        base.OnStart();
        startTime = Time.time;
        body=context.gameObject.GetComponent<Rigidbody2D>();
        m_gravity = body.gravityScale;//��������
        body.gravityScale = 0;//�Ƴ�����
        Vector2 direct;
        if (!followYAxis)//�̶����� 
        {
            float face = context.transform.localScale.x;//��ȡ��ǰ����
            direct = new Vector2(dire.x * face / Mathf.Abs(face),dire.y);//���㷽������
        }
        else
        {
            direct = context.transform.position - range.target.transform.position;//���㷽������
        }
        body.velocity = direct.normalized * speed;//��λ����������*�ٶ�
    }
    protected override State OnUpdate()
    {
        if (Time.time - startTime > time) return State.Success;
        return State.Running;
    }
    protected override void OnStop()
    {
        body.velocity = new Vector3(0, 0);//�ٶȻ�ԭ
        body.gravityScale = m_gravity;//��ԭ����
    }
}
