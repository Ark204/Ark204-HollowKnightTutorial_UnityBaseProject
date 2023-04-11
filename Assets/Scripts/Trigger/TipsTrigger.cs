using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using BerserkPixel.Prata;
//弹窗触发器
public class TipsTrigger : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;//关注的触发层
    [SerializeField] bool isTouchPlayer = false;//是否接触主角
    [SerializeField] string keyName = "upKey";//交互键
    [SerializeField] [TextArea]public string text;//提示文本
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//不在关注层内，返回
        isTouchPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//不在关注层内，返回
        isTouchPlayer = false;
    }
    private void Update()
    {
        if (isTouchPlayer && Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
        {
            BerserkPixel.Prata.DialogManager.Instance.ShowTips(text, 1.5f);
        }
    }
}
