using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveScene", menuName = "ScriptableObjct/存档场景", order = 0)]
public class SaveScene : BSaveData
{
    public string sceneName = null;
    public int targetId;//目标点ID
    protected override void OnLoad()
    {
        //读取磁盘数据
        if (PlayerPrefs.HasKey(this.name))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(this.name), sceneName);
        }
    }
    protected override void OnSave() { }
    protected override KeyValuePair<string, string> GetSaveString()
    {
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(sceneName, true));
    }

    //static
    //static SaveScene m_instance;
    //public static SaveScene Instance
    //{
    //    get
    //    {
    //        if(m_instance==null)
    //        {
    //            m_instance = Resources.Load<SaveScene>("ScriptableObject/PlayerSetting/SaveScene");
    //        }
    //        if(Instance==null)
    //        {
    //            m_instance = CreateInstance<SaveScene>();
    //        }
    //        return m_instance;
    //    }
    //}
}
