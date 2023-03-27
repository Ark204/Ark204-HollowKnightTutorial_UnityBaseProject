using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//负责接收主角传送
public class Door : BTranslate
{
#if UNITY_EDITOR
    public Color color = Color.blue;//颜色
#endif
    private void OnDrawGizmos()
    {
        Gizmos.color = color;//设置颜色
        Gizmos.DrawWireSphere(transform.position, 2f);//绘制传送点
    }
}
