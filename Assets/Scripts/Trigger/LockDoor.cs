using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɶ�̬���ص���
public class LockDoor : MonoBehaviour
{
    [SerializeField]public SaveData sceneData;//��������
    [SerializeField] int index = 0;//����
    private void Awake()
    {
        sceneData.OnSaveChange += Open;//��Ӽ���
    }
    private void OnDestroy()
    {
        sceneData.OnSaveChange -= Open;//�Ƴ�����
    }
    //����
    void Open(int index,bool value)
    {
        if (index == this.index && value == true)//�����ǲ��������Ҫ��ע������
        {
            GetComponent<Animator>().Play("Down");//���ƿ���
        }
    }
}
