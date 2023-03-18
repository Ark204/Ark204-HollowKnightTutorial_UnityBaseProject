using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//�ж��Ƿ�����
public class CheckGetHurt : ActionNode
{
    [SerializeField] int times;//�жϱ������Ĵ���
    bool m_getHit = false;
    void GetHit(Vector2 force,Vector2 dir,float damage)
    {
        m_getHit = true;
    }
    protected override void OnStart()
    {
        m_getHit = false;//�����ܻ���־λ
        context.destructable.OnHit += GetHit;//����ܻ�����
    }
    protected override State OnUpdate()
    {
        return m_getHit ? State.Success : State.Running;
    }
    protected override void OnStop() 
    {
        context.destructable.OnHit -= GetHit;//�Ƴ��ܻ�����
    }
}
