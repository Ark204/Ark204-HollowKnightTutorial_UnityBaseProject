using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数据保存基类
public abstract class BSaveData : ScriptableObject
{
    //保存时调用此函数
    protected abstract void OnSave();
    //加载时调用此函数
    protected abstract void OnLoad();
    protected virtual KeyValuePair<string, string> GetSaveString()
    {
        return default(KeyValuePair<string, string>);
    }
    protected virtual void Awake()
    {
        if (!saveDatas.Contains(this)) saveDatas.Add(this);
        if(Reset)//如果覆盖数据
        {
            var pair = GetSaveString();//获取键值对
            if (PlayerPrefs.HasKey(pair.Key)) PlayerPrefs.DeleteKey(pair.Key);//删除键值对 
        }
        OnLoad();//调用加载
    }
    protected virtual void OnEnable()
    {
        if (!saveDatas.Contains(this)) saveDatas.Add(this);
#if UNITY_EDITOR
       // OnLoad();//编辑器模式调用加载
#endif
    }
    protected virtual void OnDestroy()
    {
        if (saveDatas.Contains(this)) saveDatas.Remove(this);
    }

    //static
    protected static bool Reset = false;//覆盖标志位
    private static string ListProcessor(List<BSaveData> bSaves)
    {
        return "count:  " + bSaves.Count + "\n";
    }
    [Baracuda.Monitoring.Monitor]
    [Baracuda.Monitoring.MValueProcessor(nameof(ListProcessor))]
    static List<BSaveData> saveDatas = new List<BSaveData>();

    //用于遍历初始化所有静态数据
    public static void Save()
    {
        foreach (var elem in saveDatas)
        {
            elem.OnSave();
        }
        //遍历获取string
        foreach (var elem in saveDatas)
        {
            var pair = elem.GetSaveString();//获取键值对
            if (pair.Key == default(string)) continue;//若为默认(未重写存档对)，则跳过存档
            PlayerPrefs.SetString(pair.Key, pair.Value);//设置键值对 
        }
        PlayerPrefs.Save();//统一保存
    }
    //用于遍历初始化所有静态数据
    public static void Load()
    {
        foreach (var elem in saveDatas)
            elem.OnLoad();
    }
    //删除存档数据
    public static void DeleteAll()
    {
        Reset = true;//设置覆盖标志位
        foreach (var elem in saveDatas)
        {
            var pair = elem.GetSaveString();//获取键值对
            if(PlayerPrefs.HasKey(pair.Key)) PlayerPrefs.DeleteKey(pair.Key);//删除键值对 
        }
        PlayerPrefs.Save();//统一保存
    }
}
