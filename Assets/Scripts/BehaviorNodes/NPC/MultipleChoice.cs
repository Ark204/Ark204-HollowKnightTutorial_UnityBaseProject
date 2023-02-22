using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class MultipleChoice : CompositeNode,IDialog
{
    [SerializeField] int m_selected=-1;//�û���ѡ��
    [SerializeField] string m_text;//�Ի��ı�
    [SerializeField] List<string> m_choices=new List<string>();//ѡ���ı�

    public string Text => m_text;

    public List<string> Choices => m_choices;

    public int Selected { set => m_selected=value; }

    protected override void OnStart()
    {
        m_selected = -1;
        //�����Ի���
        DialogManager.Instance.ShowDialog(this);
    }

    protected override State OnUpdate()
    {
        if (m_selected == -1) return State.Running;//�û���δѡ�񣬷���Running
        else return children[m_selected].Update();//ִ��ѡ����ӽڵ�
    }

    protected override void OnStop()
    {
    }
}
