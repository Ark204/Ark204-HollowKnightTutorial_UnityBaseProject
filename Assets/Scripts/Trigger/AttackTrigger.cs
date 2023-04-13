using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackTrigger : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;
    [SerializeField] float damage = 1;
    [SerializeField] int id = 11;
    [SerializeField] float durTime=1f;//存在时间
    float exitTime;//已存在时间
    [SerializeField] [Range(0,1)]List<float> triggerPoints;//触发节点

    Collider2D m_collider2D;
    private void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
        //遍历每个节点
        foreach (var elem in triggerPoints)
            StartCoroutine(TQueueExtion.DelayFunc(InvokePoint, durTime * elem));//实际触发时间=总时间*节点位置
    }
    private void OnDestroy()
    {
        StopAllCoroutines();//停止所有协程
    }
    void InvokePoint()//触发节点
    {
        List<Collider2D> collider2Ds=new List<Collider2D>();
        if(m_collider2D.OverlapCollider(contactFilter2D, collider2Ds)>0)//检测范围内的所有物体
        {
            foreach(var elem in collider2Ds)
            {
                var attackAble = elem.GetComponent<BeAttackedable>();
                if (attackAble == null) continue;
                //正式命中
                attackAble.OnAttackHit(Vector2.zero, Vector2.zero, damage);
                TQueueExtion.OnSkillHurt?.Invoke(id);
            }
        }
    }
}
