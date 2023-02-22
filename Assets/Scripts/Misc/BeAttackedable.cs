using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Baracuda.Monitoring;

public abstract class BeAttackedable:MonitoredBehaviour//MonoBehaviour
{
    [Flags]
    public enum AttackType//���ܵĹ�������
    {
        Physics=1,
        Magic=2<<1
    }

    [SerializeField] AttackType m_acceptType=AttackType.Physics|AttackType.Magic;//�ܻ��������ܵĹ�������(�ɶ�ѡ)
    public void AddAttackType(AttackType type) { m_acceptType |= type; }
    public void RemoveAttackType(AttackType type) { m_acceptType &= (~type); }
    public bool ContainAttackType(AttackType type) { return (m_acceptType & type) != 0; }

    public event Action<Vector2, Vector2,float> OnHit;
    public virtual void OnAttackHit(Vector2 position, Vector2 force, float damage)
    {
        OnHit?.Invoke(position,force,damage);
    }
    //---------Modifier-------------
    [Monitor][MPosition(UIPosition.UpperRight)] public bool marked=false;
    float durTime=0f;//��Update�и���
    public void AddModifier(float time=3f)//��ӱ��
    {
        marked = true;
        durTime = time;
    }
    public void RemoveModifier()
    {
        durTime = 0;
    }
    private void Update()
    {
        if (durTime > 0) durTime -= Time.deltaTime;
        else if (marked) marked = false;
    }
}

