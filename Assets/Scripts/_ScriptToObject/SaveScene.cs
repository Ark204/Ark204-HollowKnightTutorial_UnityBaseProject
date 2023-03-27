using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveScene", menuName = "ScriptableObjct/�浵����", order = 0)]
public class SaveScene : BSaveData
{
    public string sceneName = null;
    public int targetId=1;//Ŀ���ID
    //Util
    public void MainMenu()
    {
        SceneUtil.Instance.MainMenu();//�ص����˵�
    }
    //ָ��ת��
    public void TransScene(string sceneName, int targetId)
    {
        SceneUtil.Instance.TransScene(sceneName, targetId);
    }
    //�ص��浵��
    public void TransScene()
    {
        SceneUtil.Instance.TransScene(sceneName, targetId);
    }
    //Save about
    protected override void OnLoad()
    {
        //��ȡ��������
        if (PlayerPrefs.HasKey(this.name))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(this.name), this);
        }
        else
        {
            //��ʼ������
            sceneName = "scene1";
            targetId = 1;
        }
    }
    protected override void OnSave() { }
    protected override KeyValuePair<string, string> GetSaveString()
    {
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(this, true));
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
