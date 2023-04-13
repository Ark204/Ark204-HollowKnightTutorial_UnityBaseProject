using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackTrigger : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;
    [SerializeField] float damage = 1;
    [SerializeField] int id = 11;
    [SerializeField] float durTime=1f;//����ʱ��
    float exitTime;//�Ѵ���ʱ��
    [SerializeField] [Range(0,1)]List<float> triggerPoints;//�����ڵ�

    Collider2D m_collider2D;
    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
        //����ÿ���ڵ�
        foreach (var elem in triggerPoints)
            StartCoroutine(TQueueExtion.DelayFunc(InvokePoint, durTime * elem));//ʵ�ʴ���ʱ��=��ʱ��*�ڵ�λ��
    }
    private void OnDestroy()
    {
        StopAllCoroutines();//ֹͣ����Э��
    }
    void InvokePoint()//�����ڵ�
    {
        List<Collider2D> collider2Ds=new List<Collider2D>();
        if(m_collider2D.OverlapCollider(contactFilter2D, collider2Ds)>0)//��ⷶΧ�ڵ���������
        {
            foreach(var elem in collider2Ds)
            {
                var attackAble = elem.GetComponent<BeAttackedable>();
                if (attackAble == null) continue;
                //��ʽ����
                attackAble.OnAttackHit(Vector2.zero, Vector2.zero, damage);
                TQueueExtion.OnSkillHurt?.Invoke(id);
            }
        }
    }
}
