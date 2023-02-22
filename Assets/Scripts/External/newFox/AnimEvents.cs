using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
    Rigidbody2D m_rigidbody2D;
    [SerializeField] float radius=2;//半径
    [SerializeField] float pullforce=20;//弹力
    [SerializeField] LayerMask mask;
    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SilkTan()
    {
        //获取移动方向
        Vector2 direct = m_rigidbody2D.velocity.normalized*radius/2;
        Vector2 center = new Vector2(transform.position.x + direct.x, transform.position.y + direct.y);
        Collider2D[] collider2Ds=new Collider2D[1];
        int count= Physics2D.OverlapCircleNonAlloc(center, radius/2, collider2Ds, mask);
        if(count>0)
        {
            Debug.Log("反弹"+count);
            m_rigidbody2D.velocity = new Vector2(0/*m_rigidbody2D.velocity.x*/, pullforce);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
