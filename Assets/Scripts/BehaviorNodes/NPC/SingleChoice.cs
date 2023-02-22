using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class SingleChoice : ActionNode
{
    [SerializeField] public string text;//�Ի�������
    //TODO:�Ի���

    protected override void OnStart()
    {
        //�����Ի���
        DialogManager.Instance.ShowDialog(text);
    }

    protected override State OnUpdate()
    {
        //�ȵ��û�ѡ��󷵻أ� �ж϶Ի� ����Fail�������Ի� ����Succeed δ�����κβ��� ����Update
        if (Input.GetKeyUp(KeyCode.G)) return State.Success;
        else if (Input.GetKeyUp(KeyCode.Escape)) return State.Failure;
        else return  State.Running;
    }

    protected override void OnStop()
    {
    }

}
