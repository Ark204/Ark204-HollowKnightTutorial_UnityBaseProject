using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//��Ʒ���ӡ�����
public class UseThing : ActionNode
{
    [SerializeField] Bag bag;//��������
    [SerializeField] ItemInfo info;//��Ʒ��Ϣ
    [SerializeField] int count = -1;//����(����0�����ӣ�С��0�����)
    protected override void OnStart() { }
    protected override State OnUpdate()
    {
        if (count >= 0)//����
        {
            bag.AddItem(info, (uint)count);//������Ʒ
            return State.Success;
        }
        else
        {
            return bag.SubItem(info, (uint)(-count)) ? State.Success : State.Failure;//����������Ʒ�����غ���ִ�з���ֵ
        }
    }
    protected override void OnStop() { }
}
