using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//负责跨场景传送主角
public class SendTo : MonoBehaviour
{
    [SerializeField] string sceneName;//目标场景名
    [SerializeField] int m_TargetId;//目标ID
    [SerializeField] LayerMask triggerLayer;//关注的触发层
    [SerializeField] string keyName=null;//键名，默认为空->入触型
    //入触型
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0|| 
            InputManager.Instance.inputSystemDic.ContainsKey(keyName)) return;//不在关注层中||交互型 ->返回
        SceneUtil.Instance.TransScene(sceneName, m_TargetId);//转移到对应场景的对应ID
    }
    //交互型
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!InputManager.Instance.inputSystemDic.ContainsKey(keyName)) return;//键为空->入触型->直接返回
        //在关注层中&&按下交互键
        if ((triggerLayer.value & 1 << collision.gameObject.layer) > 0 &&
            Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
        {
            SceneUtil.Instance.TransScene(sceneName, m_TargetId);//转移到对应场景的对应ID
        }
    }
}
