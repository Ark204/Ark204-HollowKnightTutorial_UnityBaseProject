using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//存档刷新型，运行时静态数据
[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/磁盘保存数据", order = 0)]
public class SaveData : BSaveData
{
    [SerializeField] int saveCount=1;//持久列表的数目
    //false为全体初始默认状态
    public List<bool> bools = new List<bool>();//运行时的列表(false)
    public List<bool> saveBools = new List<bool>();//持久保存的列表(true)
    /// <summary>
    /// 读取
    /// </summary>
    /// <param name="index"></param>
    /// <param name="target">true为持久列表，false为运行列表</param>
    /// <returns></returns>
    //public bool GetBool(int index,bool target=true)
    //{
    //    if (!target) return bools[index];//从运行时列表找
    //    else return saveBools[index];//从持久保存列表找
    //}
    ///// <summary>
    ///// 写入
    ///// </summary>
    ///// <param name="index"></param>
    ///// <param name="value">true为持久列表，false为运行列表</param>
    //public void SetBool(int index, bool value,bool target=true)
    //{
    //    if (!target)
    //    {
    //        bools[index] = value;//从运行时列表改
    //    }
    //    else
    //    {
    //        saveBools[index] = value;//从持久保存列表改
    //    }
    //}
    //SaveAbout
    //保存时调用此函数
    protected override void OnSave()
    {
        //重置运行时列表
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = false;
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
        //从磁盘读取持久列表
        if (PlayerPrefs.HasKey(this.name))
        {
            //反序列化出List
            saveBools = JsonUtility.FromJson<SerializationList<bool>>(PlayerPrefs.GetString(this.name)).ToList();
        }
        else//空档
        {
            saveBools = new List<bool>();//创建空列表 TODO:数目
            for(int i=0;i<saveCount;i++)//初始化
            {
                saveBools.Add(false);
            }
        }
    }
    protected override KeyValuePair<string, string> GetSaveString()
    {
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(new SerializationList<bool>(saveBools), true));
    }
}
