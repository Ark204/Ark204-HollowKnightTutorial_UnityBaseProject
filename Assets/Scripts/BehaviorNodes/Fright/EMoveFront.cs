using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�ƶ��ӽ����
public class EMoveFront : EnemyAction
{
    [SerializeField] [Range(-1, 1)] int baseFace = 1;//��ʼ����(Ĭ�ϳ��� Ϊ1)
    public float speed = 3f;//�ƶ��ٶ�
    public float stoppingDistance = 2.5f;//ֹͣ����
    protected override State OnUpdate() {
        //��ʼ�ƶ�
        if (range.target == null) return State.Failure;//��ʧĿ��
        if (Vector2.Distance(range.target.position, context.transform.position) > stoppingDistance)//�ж�ʣ�����
        {
            context.transform.position = Vector2.MoveTowards(context.transform.position,
                 new Vector2(range.target.position.x, context.transform.position.y), speed * Time.deltaTime);
            return State.Running;//ֹͣ�ƶ�
        }
        else return State.Success;//�ƶ����);
    }
}
