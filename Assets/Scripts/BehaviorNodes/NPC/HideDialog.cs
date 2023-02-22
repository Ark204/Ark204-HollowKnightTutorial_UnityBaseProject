using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

//用于控制对话框开启或关闭
public class HideDialog : ActionNode
{
    [SerializeField] bool turnOn=false;//true打开false关闭

    protected override void OnStart()
    {
        if(!turnOn) DialogManager.Instance.HideDialog();//关闭对话框
    }
    protected override State OnUpdate()
    {
        return State.Success;
    }
    protected override void OnStop()
    {
    }

}
