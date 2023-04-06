using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//���ݹ��� ���ڸ����������ṩ��������ֵ
public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] public SaveData m_saveData;//��������Ӧ������
    [SerializeField] List<UnityEvent> awakeSaveEvents;//��������Awake��Ӧ���ӻ��¼��б�TODO:OnTrue(��һ״̬)
    [SerializeField] List<UnityEvent> changeSaveEvents;//��������Change��Ӧ���ӻ��¼��б�
    //TODO������ʱ
    //TODO: ����Ϊfalse
    protected override void Awake()
    {
        base.Awake();
        //�����־����б�
        for(int i=0;i<awakeSaveEvents.Count;i++)
        {
            if (m_saveData.saveBools[i]==false) awakeSaveEvents[i]?.Invoke();//ֵΪfalse->Ĭ��(��ʼ)->���ô���
            //TODO:true�б�
        }
        //TODO:��������ʱ�б�
    }
    public bool GetSaveBool(int index) 
    {
        return m_saveData.saveBools[index];//��������ʱ�б��ж�Ӧ��������ֵ
    }
    public void SetSaveBool(int index) 
    {
        //��������ʱ�б��ж�Ӧ��������ֵ
        m_saveData.saveBools[index]= !m_saveData.saveBools[index];//ȡ��
        if(m_saveData.saveBools[index] == true) changeSaveEvents[index]?.Invoke();//�����ı��¼�(�־�&&SetTrue)
        //TODO:(�־�&&SetFalse)
    }
    //TODO:����ʱ
}
