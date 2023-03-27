using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using BerserkPixel.Prata;

public class SingleChoice : ActionNode, IDialog
{
    static string keyName = "upKey";//����������Ĭ��ΪupKey->�봥��

    [SerializeField] string m_authorName;
    [SerializeField] [TextArea] string m_text;//�Ի��ı�
    [SerializeField] bool m_isFacingRight = true;
    [SerializeField] Texture2D m_texture2D;
    //interface
    public string authorName { get => m_authorName; }//�Ի�������
    public string Text => m_text;
    public List<string> Choices => new List<string>();
    public int Selected { set { } }
    public bool isFacingRight { get => m_isFacingRight; }//ͼƬ����
    //�Ի���ͼ��
    public Sprite GetImage()
    {
        return Sprite.Create(m_texture2D, new Rect(0, 0, m_texture2D.width, m_texture2D.height),
             new Vector2(0.5f, 0.5f));
    }
    protected override void OnStart()
    {
        //�����Ի���
        DialogManager.Instance.ShowDialog(this);
    }

    protected override State OnUpdate()
    {
        //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;//��UI�򿪣�ֱ�ӷ���
        //�ȵ��û�ѡ��󷵻أ� �ж϶Ի� ����Fail�������Ի� ����Succeed δ�����κβ��� ����Update
        if (Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName])) return State.Success;
        else if (Input.GetKeyDown(KeyCode.Escape)) return State.Failure;
        else return  State.Running;
    }

    protected override void OnStop()
    {
    }

}
