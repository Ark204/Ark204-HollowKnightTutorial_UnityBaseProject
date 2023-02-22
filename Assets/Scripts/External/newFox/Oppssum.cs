using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oppssum : MonoBehaviour
{
    public float attackforce = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Fox")
        {
            // πΩ«…´ ‹…À
            //Debug.Log("attack");
            collision.gameObject.GetComponent<StateController>().ChangeState(FoxState.hurt);
            Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            Transform transform = collision.gameObject.GetComponent<Transform>();
            rigidbody2D.velocity = new Vector2(-transform.localScale.x * attackforce, 1 * attackforce);
        }
    }
}
