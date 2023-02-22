using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Collider2D m_collider2D;
    public float m_existTime = 10;
    [SerializeField] LayerMask enemy;
    [SerializeField] LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        m_collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_collider2
    }
    void FixedUpdate()
    {
        m_existTime = m_existTime - Time.fixedDeltaTime;
        if(m_existTime<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemy) != 0)
        {
            collision.collider.GetComponent<BeAttackedable>().OnAttackHit(transform.position, Vector2.zero, 3);
        }
        else if(((1 << collision.gameObject.layer) & player) != 0)
        {
            Destroy(gameObject);
        }
    }
    //void OnTrigerEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}


}
