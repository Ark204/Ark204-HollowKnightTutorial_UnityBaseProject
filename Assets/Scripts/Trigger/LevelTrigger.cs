using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//关卡触发器
public class LevelTrigger : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;
    //镜头控制
    //[SerializeField] CinemachineVirtualCameraBase Main;
    //[SerializeField] CinemachineVirtualCameraBase Boss;
    ////区域控制
    //[SerializeField] GameObject[] doors;
    ////怪物生成控制
    [SerializeField] int index;//数据索引
    //触发事件
    public UnityEngine.Events.UnityEvent triggerEvent = new UnityEngine.Events.UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
        {
            isTouchPlayer = true;
            //Core.Character.CameraController.Instance.SetBorders(collision);
            //Main.VirtualCameraGameObject.SetActive(false);
            //Boss.VirtualCameraGameObject.SetActive(true);
            //if (DataManager.Instance.GetBool(index))//若从未通关
            {
                triggerEvent?.Invoke();//调用触发事件
                Destroy(this);//销毁本组件
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
}
