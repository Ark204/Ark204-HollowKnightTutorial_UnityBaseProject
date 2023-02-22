using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

//���ڿ��ƶԻ�������ر�
public class HideDialog : ActionNode
{
    [SerializeField] bool turnOn=false;//true��false�ر�

    protected override void OnStart()
    {
        if(!turnOn) DialogManager.Instance.HideDialog();//�رնԻ���
    }
    protected override State OnUpdate()
    {
        return State.Success;
    }
    protected override void OnStop()
    {
    }

}
