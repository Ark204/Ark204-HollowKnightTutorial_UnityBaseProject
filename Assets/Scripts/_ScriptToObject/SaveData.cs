using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存档刷新型，运行时静态数据
[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/磁盘保存数据", order = 0)]
public class SaveData : BSaveData
{
    public List<bool> bools = new List<bool>();
    //保存时调用此函数
    protected override void OnSave()
    {
        //重置
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = true;
        }
    }
    //加载时调用此函数
    protected override void OnLoad()
    {
        //重置
        for (int i = 0; i < bools.Count; i++)
        {
            bools[i] = true;
        }
    }
}
