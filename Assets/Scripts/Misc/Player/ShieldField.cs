using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Physics2D.IgnoreLayerCollision(6, 8);//设置无敌
            collision.GetComponent<PlayerCtrl>().CanBeHit = false;//使主角不能被命中
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Physics2D.IgnoreLayerCollision(6, 8,false);//移除无敌
            collision.GetComponent<PlayerCtrl>().CanBeHit = true;//使主角可以被命中
        }
    }
}
