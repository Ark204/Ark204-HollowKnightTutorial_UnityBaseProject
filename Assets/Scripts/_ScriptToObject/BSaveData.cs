using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ݱ������
public abstract class BSaveData : ScriptableObject
{
    //����ʱ���ô˺���
    protected abstract void OnSave();
    //����ʱ���ô˺���
    protected abstract void OnLoad();
    protected virtual KeyValuePair<string, string> GetSaveString()
    {
        return default(KeyValuePair<string, string>);
    }
    protected virtual void Awake()
    {
        if (!saveDatas.Contains(this)) saveDatas.Add(this);
        if(Reset)//�����������
        {
            var pair = GetSaveString();//��ȡ��ֵ��
            if (PlayerPrefs.HasKey(pair.Key)) PlayerPrefs.DeleteKey(pair.Key);//ɾ����ֵ�� 
        }
        OnLoad();//���ü���
    }
    protected virtual void OnEnable()
    {
        if (!saveDatas.Contains(this)) saveDatas.Add(this);
#if UNITY_EDITOR
       // OnLoad();//�༭��ģʽ���ü���
#endif
    }
    protected virtual void OnDestroy()
    {
        if (saveDatas.Contains(this)) saveDatas.Remove(this);
    }

    //static
    protected static bool Reset = false;//���Ǳ�־λ
    private static string ListProcessor(List<BSaveData> bSaves)
    {
        return "count:  " + bSaves.Count + "\n";
    }
    [Baracuda.Monitoring.Monitor]
    [Baracuda.Monitoring.MValueProcessor(nameof(ListProcessor))]
    static List<BSaveData> saveDatas = new List<BSaveData>();

    //���ڱ�����ʼ�����о�̬����
    public static void Save()
    {
        foreach (var elem in saveDatas)
        {
            elem.OnSave();
        }
        //������ȡstring
        foreach (var elem in saveDatas)
        {
            var pair = elem.GetSaveString();//��ȡ��ֵ��
            if (pair.Key == default(string)) continue;//��ΪĬ��(δ��д�浵��)���������浵
            PlayerPrefs.SetString(pair.Key, pair.Value);//���ü�ֵ�� 
        }
        PlayerPrefs.Save();//ͳһ����
    }
    //���ڱ�����ʼ�����о�̬����
    public static void Load()
    {
        foreach (var elem in saveDatas)
            elem.OnLoad();
    }
    //ɾ���浵����
    public static void DeleteAll()
    {
        Reset = true;//���ø��Ǳ�־λ
        foreach (var elem in saveDatas)
        {
            var pair = elem.GetSaveString();//��ȡ��ֵ��
            if(PlayerPrefs.HasKey(pair.Key)) PlayerPrefs.DeleteKey(pair.Key);//ɾ����ֵ�� 
        }
        PlayerPrefs.Save();//ͳһ����
    }
}
