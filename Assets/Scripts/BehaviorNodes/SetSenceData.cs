using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//���ó������ݵ�ֵ
public class SetSenceData : ActionNode
{
    [SerializeField] SaveData sceneData;//��������
    [SerializeField] bool target = true;//Ҫ���õ�Ŀ���б�Ĭ��Ϊtrue->�־ñ����ͺ�
    [SerializeField] int index = 0;//����
    [SerializeField] bool value=true;//Ҫ���õ�ֵ��Ĭ��Ϊtrue
    protected override void OnStart() { }

    protected override void OnStop() { }

    protected override State OnUpdate()
    {
        sceneData.SetBool(index, value, target);//������ֵ
        return State.Success;
    }
}
