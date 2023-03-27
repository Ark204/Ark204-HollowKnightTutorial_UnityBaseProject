using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可动态开关的门
public class LockDoor : MonoBehaviour
{
    [SerializeField]public SaveData sceneData;//场景数据
    [SerializeField] int index = 0;//索引
    private void Awake()
    {
        sceneData.OnSaveChange += Open;//添加监听
    }
    private void OnDestroy()
    {
        sceneData.OnSaveChange -= Open;//移除监听
    }
    //打开门
    void Open(int index,bool value)
    {
        if (index == this.index && value == true)//看看是不是真的是要关注的数据
        {
            GetComponent<Animator>().Play("Down");//控制开门
        }
    }
}
