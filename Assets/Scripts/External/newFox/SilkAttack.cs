using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkAttack : MonoBehaviour
{
    public float Maxlength = 5;
    public float growspeed = 0.36f;//生长速度
    public bool touch = false;
    public Transform m_transform;
    public LayerMask enemy;
    void Start()
    {
        //m_transform为发射点
        m_transform = transform.parent;
    }
    private void FixedUpdate()
    {
        if (m_transform.localScale.x < Maxlength && !touch)
        {
            m_transform.localScale = new Vector3(m_transform.localScale.x + growspeed, m_transform.localScale.y, m_transform.localScale.z);
        }
        else
        {
            //还原发射点
            m_transform.rotation = new Quaternion();
            m_transform.localScale = new Vector3(1, 1, 1);
            //销毁丝线
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemy) != 0)
        {
            collision.GetComponent<BeAttackedable>().OnAttackHit(m_transform.parent.position, Vector2.zero, 1);
            touch = true;
        }
        else if (collision.gameObject.layer == 11) { Destroy(collision.gameObject); }
    }

}
