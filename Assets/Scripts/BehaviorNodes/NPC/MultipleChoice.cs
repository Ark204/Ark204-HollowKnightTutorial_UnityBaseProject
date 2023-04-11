using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class MultipleChoice : CompositeNode,IDialog
{
    [SerializeField] string m_authorName;
    [SerializeField] int m_selected=-1;//用户的选择
    [SerializeField] [TextArea] string m_text;//对话文本
    [SerializeField] List<string> m_choices=new List<string>();//选项文本
    [SerializeField] bool m_isFacingRight=true;
    [SerializeField] Texture2D m_texture2D;
    //interface
    public string authorName { get => m_authorName; }//对话者名称
    public string Text => m_text;
    public List<string> Choices => m_choices;
    public int Selected { set => m_selected=value; }
    public bool isFacingRight { get => m_isFacingRight; }//图片朝向
    //对话者图标
    public Sprite GetImage()
    {
        if (m_texture2D == null) return null;
        return Sprite.Create(m_texture2D, new Rect(0, 0, m_texture2D.width, m_texture2D.height),
             new Vector2(0.5f, 0.5f));
    }
    
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
