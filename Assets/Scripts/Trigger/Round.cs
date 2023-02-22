using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] Core.Combat.Destructable[] enemys;
    [SerializeField] int dieCount;//死亡数量
    public UnityEngine.Events.UnityEvent endEvent=new UnityEngine.Events.UnityEvent();
    private void Start()
    {
        foreach(var enemy in enemys)
        {
            enemy.OnDestroyed += CheckEnd;//添加死亡监听
            enemy.gameObject.SetActive(true);
        }
        dieCount = 0;//初始化死亡数量
    }
    //检测当轮是否结束，若结束则调用结束事件列表
    void CheckEnd()
    {
        dieCount++;
        if(enemys.Length-dieCount<=0) endEvent?.Invoke();
    }
    private void OnDestroy()
    {
        foreach (var enemy in enemys)
        {
            if (enemy)
            {
                enemy.OnDestroyed -= CheckEnd;//移除死亡监听
                //enemy.gameObject.SetActive(true);
            }
        }
        endEvent?.RemoveAllListeners();//移除所有监听
    }
}
