using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class SingleChoice : ActionNode, IDialog
{
    static string keyName = "upKey";//交互键名，默认为upKey->入触型

    [SerializeField] string m_authorName;
    [SerializeField] [TextArea] string m_text;//对话文本
    [SerializeField] bool m_isFacingRight = true;
    [SerializeField] Texture2D m_texture2D;
    //interface
    public string authorName { get => m_authorName; }//对话者名称
    public string Text => m_text;
    public List<string> Choices => new List<string>();
    public int Selected { set { } }
    public bool isFacingRight { get => m_isFacingRight; }//图片朝向
    //对话者图标
    public Sprite GetImage()
    {
        return Sprite.Create(m_texture2D, new Rect(0, 0, m_texture2D.width, m_texture2D.height),
             new Vector2(0.5f, 0.5f));
    }
    protected override void OnStart()
    {
        //开启对话框
        DialogManager.Instance.ShowDialog(this);
    }

    protected override State OnUpdate()
    {
        //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;//有UI打开，直接返回
        //等到用户选择后返回： 中断对话 返回Fail，继续对话 返回Succeed 未进行任何操作 返回Update
        if (Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName])) return State.Success;
        else if (Input.GetKeyDown(KeyCode.Escape)) return State.Failure;
        else return  State.Running;
    }

    protected override void OnStop()
    {
    }

}
