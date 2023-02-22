using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class MultipleChoice : CompositeNode,IDialog
{
    [SerializeField] int m_selected=-1;//用户的选择
    [SerializeField] string m_text;//对话文本
    [SerializeField] List<string> m_choices=new List<string>();//选项文本

    public string Text => m_text;

    public List<string> Choices => m_choices;

    public int Selected { set => m_selected=value; }

    protected override void OnStart()
    {
        m_selected = -1;
        //开启对话框
        DialogManager.Instance.ShowDialog(this);
    }

    protected override State OnUpdate()
    {
        if (m_selected == -1) return State.Running;//用户尚未选择，返回Running
        else return children[m_selected].Update();//执行选择的子节点
    }

    protected override void OnStop()
    {
    }
}
