using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    [SerializeField] Core.Combat.Destructable[] enemys;
    [SerializeField] int dieCount;//��������
    public UnityEngine.Events.UnityEvent endEvent=new UnityEngine.Events.UnityEvent();
    private void Start()
    {
        foreach(var enemy in enemys)
        {
            enemy.OnDestroyed += CheckEnd;//�����������
            enemy.gameObject.SetActive(true);
        }
        dieCount = 0;//��ʼ����������
    }
    //��⵱���Ƿ����������������ý����¼��б�
    void CheckEnd()
    {
        dieCount++;
        if(enemys.Length-dieCount<=0) endEvent?.Invoke();
    }
    private void OnDestroy()
    {
        foreach (var enemy in enemys)
        {
            if (enemy)
            {
                enemy.OnDestroyed -= CheckEnd;//�Ƴ���������
                //enemy.gameObject.SetActive(true);
            }
        }
        endEvent?.RemoveAllListeners();//�Ƴ����м���
    }
}
