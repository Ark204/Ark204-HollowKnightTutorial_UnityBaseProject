using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//与动画相关的触发器(SetBool)
public class AnimTrigger : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;//关注的触发层
    [SerializeField] Animator animator;//对应的动画控制器
    [SerializeField] string proName ="active";//参数名
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//不在关注层中 返回
        animator.SetBool(proName, !animator.GetBool(proName));//反置bool值
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//不在关注层中 返回
        animator.SetBool(proName, !animator.GetBool(proName));//反置bool值
    }
}
