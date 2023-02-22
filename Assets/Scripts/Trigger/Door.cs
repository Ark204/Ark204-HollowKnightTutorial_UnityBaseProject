using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BTranslate
{
    [SerializeField] string sceneName;
    [SerializeField] int m_TargetId;//目标ID
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer=false;
    [SerializeField] KeyCode keycode = KeyCode.Alpha7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1<<collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1<<collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
    private void Update()
    {
        if(isTouchPlayer&&Input.GetKeyDown(keycode))
        {
            SceneUtil.Instance.TransScene(sceneName,m_TargetId);//转移到对应场景的对应ID
        }
    }
    
}
