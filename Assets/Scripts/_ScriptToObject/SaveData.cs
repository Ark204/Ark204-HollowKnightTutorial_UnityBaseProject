using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/磁盘保存数据", order = 0)]
public class SaveData : BSaveData
{
    public List<bool> bools = new List<bool>();
    //保存时调用此函数
    protected override void OnSave()
    {
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = true;
        }
    }
    //加载时调用此函数
    protected override void OnLoad()
    {
        for (int i = 0; i < bools.Count; i++)
        {
            bools[i] = true;
        }
    }
}
