using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class SingleChoice : ActionNode
{
    [SerializeField] public string text;//对话的内容
    //TODO:对话者

    protected override void OnStart()
    {
        //开启对话框
        DialogManager.Instance.ShowDialog(text);
    }

    protected override State OnUpdate()
    {
        //等到用户选择后返回： 中断对话 返回Fail，继续对话 返回Succeed 未进行任何操作 返回Update
        if (Input.GetKeyUp(KeyCode.G)) return State.Success;
        else if (Input.GetKeyUp(KeyCode.Escape)) return State.Failure;
        else return  State.Running;
    }

    protected override void OnStop()
    {
    }

}
