using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creater : MonoBehaviour
{
    [SerializeField] int index;//��������
    protected bool Value { 
        get => DataManager.Instance.GetSaveBool(index);
        set=> DataManager.Instance.SetSaveBool(index);//ֱ��ȡ�� 
    }
}
