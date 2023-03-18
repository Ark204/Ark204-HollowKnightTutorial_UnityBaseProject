using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//触发自毁组件
public class DestoryTri : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer ;//关注的触发层
    [SerializeField] GameObject destoryObj;//自毁时销毁的物体
    public event System.Action onDestory;//自毁事件
    private void Awake() { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//不在关注层中 返回
        Debug.Log(collision.gameObject.name + "  :" + collision.gameObject.layer+"触发移动");
        onDestory?.Invoke();
        GameObject destory = destoryObj == null ? gameObject : destoryObj;//若没有指定销毁物体，则销毁自身
        Destroy(destory);//只能销毁自身，父物体依旧存在
    }
}
