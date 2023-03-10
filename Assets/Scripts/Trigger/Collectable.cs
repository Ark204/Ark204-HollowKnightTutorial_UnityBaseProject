using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;
    [SerializeField] ItemInfo info;//物品对应的Info
    [SerializeField] Bag bag;//对应的背包
    [SerializeField] uint count = 1;//物品数量
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
        {
            isTouchPlayer = true;
            {
                bag.AddItem(info, count);//向背包中添加指定数量的物品
                Destroy(transform.parent.gameObject);//销毁本组件
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
}
