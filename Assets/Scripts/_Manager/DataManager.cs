using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ݹ��� ���ڸ����������ṩ��������ֵ
public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] SaveData m_saveData;//��������Ӧ������
    public bool GetBool(int index)
    {
        return m_saveData.bools[index];
    }
    public void SetBool(int index,bool value)
    {
        m_saveData.bools[index] = value;
    }
}
