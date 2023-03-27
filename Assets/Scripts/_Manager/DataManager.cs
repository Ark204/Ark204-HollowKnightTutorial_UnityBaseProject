using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数据管理 用于给场景数据提供保存数据值
public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] public SaveData m_saveData;//创建器对应的数据
}
