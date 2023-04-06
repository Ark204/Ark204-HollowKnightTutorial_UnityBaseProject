using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�浵ˢ���ͣ�����ʱ��̬����
[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/���̱�������", order = 0)]
public class SaveData : BSaveData
{
    [SerializeField] int saveCount=1;//�־��б����Ŀ
    //falseΪȫ���ʼĬ��״̬
    public List<bool> bools = new List<bool>();//����ʱ���б�(false)
    public List<bool> saveBools = new List<bool>();//�־ñ�����б�(true)
    /// <summary>
    /// ��ȡ
    /// </summary>
    /// <param name="index"></param>
    /// <param name="target">trueΪ�־��б�falseΪ�����б�</param>
    /// <returns></returns>
    //public bool GetBool(int index,bool target=true)
    //{
    //    if (!target) return bools[index];//������ʱ�б���
    //    else return saveBools[index];//�ӳ־ñ����б���
    //}
    ///// <summary>
    ///// д��
    ///// </summary>
    ///// <param name="index"></param>
    ///// <param name="value">trueΪ�־��б�falseΪ�����б�</param>
    //public void SetBool(int index, bool value,bool target=true)
    //{
    //    if (!target)
    //    {
    //        bools[index] = value;//������ʱ�б��
    //    }
    //    else
    //    {
    //        saveBools[index] = value;//�ӳ־ñ����б��
    //    }
    //}
    //SaveAbout
    //����ʱ���ô˺���
    protected override void OnSave()
    {
        //��������ʱ�б�
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = false;
        }
    }
    //����ʱ���ô˺���
    protected override void OnLoad()
    {
        //��������ʱ�б�
        for (int i = 0; i < bools.Count; i++)
        {
            bools[i] = false;
        }
        //�Ӵ��̶�ȡ�־��б�
        if (PlayerPrefs.HasKey(this.name))
        {
            //�����л���List
            saveBools = JsonUtility.FromJson<SerializationList<bool>>(PlayerPrefs.GetString(this.name)).ToList();
        }
        else//�յ�
        {
            saveBools = new List<bool>();//�������б� TODO:��Ŀ
            for(int i=0;i<saveCount;i++)//��ʼ��
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
