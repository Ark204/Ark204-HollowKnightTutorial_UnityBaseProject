using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class MultipleChoice : CompositeNode,IDialog
{
    [SerializeField] string m_authorName;
    [SerializeField] int m_selected=-1;//�û���ѡ��
    [SerializeField] [TextArea] string m_text;//�Ի��ı�
    [SerializeField] List<string> m_choices=new List<string>();//ѡ���ı�
    [SerializeField] bool m_isFacingRight=true;
    [SerializeField] Texture2D m_texture2D;
    //interface
    public string authorName { get => m_authorName; }//�Ի�������
    public string Text => m_text;
    public List<string> Choices => m_choices;
    public int Selected { set => m_selected=value; }
    public bool isFacingRight { get => m_isFacingRight; }//ͼƬ����
    //�Ի���ͼ��
    public Sprite GetImage()
    {
        if (m_texture2D == null) return null;
        return Sprite.Create(m_texture2D, new Rect(0, 0, m_texture2D.width, m_texture2D.height),
             new Vector2(0.5f, 0.5f));
    }
    
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
