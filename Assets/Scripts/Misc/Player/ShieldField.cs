using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Physics2D.IgnoreLayerCollision(6, 8);//�����޵�
            collision.GetComponent<PlayerCtrl>().CanBeHit = false;//ʹ���ǲ��ܱ�����
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Physics2D.IgnoreLayerCollision(6, 8,false);//�Ƴ��޵�
            collision.GetComponent<PlayerCtrl>().CanBeHit = true;//ʹ���ǿ��Ա�����
        }
    }
}
