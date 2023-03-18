using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//Ѫ�����
public class EStiff : ActionNode
{
    [SerializeField] [Range(0, 1)] List<float> points;//����
    [SerializeField] int curr=0;//��ǰ������
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        if (curr + 1 > points.Count) return State.Failure;//��Խ����=�Ѿ�û�м�����->����Failure
        if ((float)context.destructable.CurrentHealth / (float)context.destructable.health <= points[curr])
        {
            curr++;//�����¸�������
            return State.Success;//����Ѫ�ޣ�����Succeed
        }
        else return State.Failure;//�Ը���Ѫ�ޣ�����Failure
    }
    protected override void OnStop() { }
}
