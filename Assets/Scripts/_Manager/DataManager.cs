using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数据管理 用于给场景数据提供保存数据值
public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] SaveData m_saveData;//创建器对应的数据
    public bool GetBool(int index)
    {
        return m_saveData.bools[index];
    }
    public void SetBool(int index,bool value)
    {
        m_saveData.bools[index] = value;
    }
}
