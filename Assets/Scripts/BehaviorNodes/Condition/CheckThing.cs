using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//���ڼ���ɫ�����Ƿ���ĳ����Ʒ
public class CheckThing : ActionNode
{
    [SerializeField] Bag bag;//��������
    [SerializeField] ItemInfo info;//��Ʒ��Ϣ
    [SerializeField] int count=1;//����
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        return bag.FindItem(info) >= count? State.Success:State.Failure;
    }
    protected override void OnStop() { }
}
