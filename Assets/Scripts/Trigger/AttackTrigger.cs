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
    private void Start()
    {
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
        var colldier = GetComponent<Collider2D>();
        List<Collider2D> collider2Ds=new List<Collider2D>();
        if(colldier.OverlapCollider(contactFilter2D, collider2Ds)>0)//��ⷶΧ�ڵ���������
        {
            foreach(var elem in collider2Ds)
            {
                elem.GetComponent<BeAttackedable>().OnAttackHit(Vector2.zero, Vector2.zero, damage);
                TQueueExtion.OnSkillHurt?.Invoke(id);
            }
        }
    }
}
