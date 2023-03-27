using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存档刷新型，运行时静态数据
[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/磁盘保存数据", order = 0)]
public class SaveData : BSaveData
{
    //false为全体初始默认状态
    [SerializeField] List<bool> bools = new List<bool>();//运行时的列表(false)
    public List<bool> saveBools = new List<bool>();//持久保存的列表(true)
    public event System.Action<int,bool> OnRunTimeChange;//当运行时列表变化调用
    public event System.Action<int, bool> OnSaveChange;//当持久保存列表变化调用
    /// <summary>
    /// 读取
    /// </summary>
    /// <param name="index"></param>
    /// <param name="target">true为运行时列表，false为持久保存的列表</param>
    /// <returns></returns>
    public bool GetBool(int index,bool target=true)
    {
        if (!target) return bools[index];//从运行时列表找
        else return saveBools[index];//从持久保存列表找
    }
    /// <summary>
    /// 写入
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value">true为运行时列表，false为持久保存的列表</param>
    public void SetBool(int index, bool value,bool target=true)
    {
        if (!target)
        {
            bools[index] = value;//从运行时列表改
            OnRunTimeChange?.Invoke(index, value);
        }
        else
        {
            saveBools[index] = value;//从持久保存列表改
            OnSaveChange?.Invoke(index, value);
        }
    }
    //保存时调用此函数
    protected override void OnSave()
    {
        //重置运行时列表
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = false;
        }
        for (int i = 0; i < saveBools.Count; i++)
        {
            saveBools[i] = false;
        }
    }
    //加载时调用此函数
    protected override void OnLoad()
    {
        //重置运行时列表
        for (int i = 0; i < bools.Count; i++)
        {
            bools[i] = false;
        }
        for (int i = 0; i < saveBools.Count; i++)
        {
            saveBools[i] = false;
        }
    }
}
