using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可动态开关的门
public class LockDoor : MonoBehaviour
{
    [SerializeField]bool m_isLock=false;//门当前开关状态
    [SerializeField] float offset = 3f;
    [SerializeField] float time=1f;//动画时间
    float speed;//移动速度
    float currentTime = 0f;//剩余移动时间
    public bool IsLock {
        get => m_isLock;
        set
        {
            if (value == m_isLock) return;//状态不变 直接返回
            m_isLock = value;//更新状态
            if (value == true) speed = offset / time; //由关到开
            else speed = -offset / time;//由开到关
            currentTime = time;
        }
    }
    private void FixedUpdate()
    {
        if (currentTime <= 0) return;
        transform.Translate(0, Time.fixedDeltaTime*speed, 0);
        currentTime -= Time.fixedDeltaTime;//剩余移动时间减少
    }
}
