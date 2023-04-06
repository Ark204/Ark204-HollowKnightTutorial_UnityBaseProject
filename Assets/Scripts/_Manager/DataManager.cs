using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//数据管理 用于给场景数据提供保存数据值
public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] public SaveData m_saveData;//创建器对应的数据
    [SerializeField] List<UnityEvent> awakeSaveEvents;//场景数据Awake对应的视化事件列表TODO:OnTrue(另一状态)
    [SerializeField] List<UnityEvent> changeSaveEvents;//场景数据Change对应的视化事件列表
    //TODO：运行时
    //TODO: 重设为false
    protected override void Awake()
    {
        base.Awake();
        //遍历持久型列表
        for(int i=0;i<awakeSaveEvents.Count;i++)
        {
            if (m_saveData.saveBools[i]==false) awakeSaveEvents[i]?.Invoke();//值为false->默认(初始)->调用触发
            //TODO:true列表
        }
        //TODO:遍历运行时列表
    }
    public bool GetSaveBool(int index) 
    {
        return m_saveData.saveBools[index];//返回运行时列表中对应索引处的值
    }
    public void SetSaveBool(int index) 
    {
        //设置运行时列表中对应索引处的值
        m_saveData.saveBools[index]= !m_saveData.saveBools[index];//取反
        if(m_saveData.saveBools[index] == true) changeSaveEvents[index]?.Invoke();//触发改变事件(持久&&SetTrue)
        //TODO:(持久&&SetFalse)
    }
    //TODO:运行时
}
