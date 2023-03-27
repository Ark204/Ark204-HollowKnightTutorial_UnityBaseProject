using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�浵ˢ���ͣ�����ʱ��̬����
[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/���̱�������", order = 0)]
public class SaveData : BSaveData
{
    //falseΪȫ���ʼĬ��״̬
    [SerializeField] List<bool> bools = new List<bool>();//����ʱ���б�(false)
    public List<bool> saveBools = new List<bool>();//�־ñ�����б�(true)
    public event System.Action<int,bool> OnRunTimeChange;//������ʱ�б�仯����
    public event System.Action<int, bool> OnSaveChange;//���־ñ����б�仯����
    /// <summary>
    /// ��ȡ
    /// </summary>
    /// <param name="index"></param>
    /// <param name="target">trueΪ����ʱ�б�falseΪ�־ñ�����б�</param>
    /// <returns></returns>
    public bool GetBool(int index,bool target=true)
    {
        if (!target) return bools[index];//������ʱ�б���
        else return saveBools[index];//�ӳ־ñ����б���
    }
    /// <summary>
    /// д��
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value">trueΪ����ʱ�б�falseΪ�־ñ�����б�</param>
    public void SetBool(int index, bool value,bool target=true)
    {
        if (!target)
        {
            bools[index] = value;//������ʱ�б��
            OnRunTimeChange?.Invoke(index, value);
        }
        else
        {
            saveBools[index] = value;//�ӳ־ñ����б��
            OnSaveChange?.Invoke(index, value);
        }
    }
    //����ʱ���ô˺���
    protected override void OnSave()
    {
        //��������ʱ�б�
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = false;
        }
        for (int i = 0; i < saveBools.Count; i++)
        {
            saveBools[i] = false;
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
        for (int i = 0; i < saveBools.Count; i++)
        {
            saveBools[i] = false;
        }
    }
}
