using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveScene", menuName = "ScriptableObjct/�浵����", order = 0)]
public class SaveScene : BSaveData
{
    public string sceneName = null;
    public int targetId;//Ŀ���ID
    protected override void OnLoad()
    {
        //��ȡ��������
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
