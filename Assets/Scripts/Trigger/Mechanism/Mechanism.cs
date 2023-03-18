using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//强制移动
public class Mechanism : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer ;//关注的触发层
    [SerializeField]Vector2 position;//传送点坐标
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//不在关注层中 返回
        collision.transform.position = position;//强制传送
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(position, 2f);//绘制传送点
    }
}
