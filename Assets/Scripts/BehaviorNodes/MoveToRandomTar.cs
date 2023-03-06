using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//����������ƶ�
public class MoveToRandomTar : ActionNode
{
    [SerializeField] [Range(-1, 1)] int baseFace = 1;//��ʼ����(Ĭ�ϳ��� Ϊ1)
    [SerializeField]Vector2 xRange=new Vector2(-10,10);//x�᷶Χ
    float targetX;//�����ƶ������X����
    [SerializeField] float minDistance;//��һ�����Ѳ�ߵ����С����
    public float speed = 5;//�ƶ��ٶ�
    public float stoppingDistance = 0.1f;//ֹͣ����
    protected override void OnStart()
    {
        float x = Random.Range(xRange.x, xRange.y - 2 * minDistance);
        if (x > context.transform.position.x - minDistance) x += 2 * minDistance;
        targetX = x;//��ȡ��������
        //���������
        if (targetX - context.transform.position.x > 0) context.transform.localScale = new Vector3(-baseFace, context.transform.localScale.y, context.transform.localScale.z);
        else if (targetX - context.transform.position.x < 0) context.transform.localScale = new Vector3(baseFace, context.transform.localScale.y, context.transform.localScale.z);
    }
    protected override State OnUpdate()
    {
        //��ʼ�ƶ�
        if (Mathf.Abs(targetX - context.transform.position.x) > stoppingDistance)//�ж�ʣ�����
        {
            context.transform.position = Vector2.MoveTowards(context.transform.position,
                 new Vector2(targetX,context.transform.position.y), speed * Time.deltaTime);
            return State.Running;//ֹͣ�ƶ�
        }
        else return State.Success;//�ƶ����
    }

    protected override void OnStop() { }
    public override void OnDrawGizmos()
    {
        if (context == null||context.transform==null) return;  
        Gizmos.DrawWireCube(new Vector3((xRange.x+xRange.y)/2,context.transform.position.y,0), new Vector3(Mathf.Abs(xRange.x-xRange.y), 3, 0));
    }
}
