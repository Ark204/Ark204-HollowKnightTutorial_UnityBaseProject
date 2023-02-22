using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;
using DG.Tweening;

public class CircleMove : BDele
{
    [SerializeField] float time;
    [SerializeField] float radus;
    float m_gravityScale;
    Tweener tweenPath;
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        playerCtrl.EnableMoveCtrl = false;//�����ƶ�ģ��
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        m_gravityScale = rigidbody2D.gravityScale;//��������
        rigidbody2D.gravityScale = 0;//ȡ������
        //behaviorCtrl.modifierAcceptor.AddModifier(m_modifier2);//����޵�״̬
        Vector3[] path = new Vector3[5];
        path[0] = skillManager.transform.position;//��ʼ��
        float direct = skillManager.transform.localScale.x;//�������ǳ���
        Vector3 center = new Vector3(path[0].x +  direct* radus, path[0].y, path[0].z);//�����Բ��
        path[1] = center + radus * new Vector3(-0.707f*direct, 0.707f, 0);
        path[2] = center + radus * new Vector3(0, 1, 0);
        path[3] = center + radus * new Vector3(0.707f * direct, 0.707f, 0);
        path[4] = center + radus * new Vector3(direct, 0, 0);
        tweenPath = skillManager.transform.DOPath(path, time, PathType.CatmullRom).SetEase(Ease.Linear);
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        tweenPath?.Kill();
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = m_gravityScale;//��ԭ����
        //behaviorCtrl.modifierAcceptor.RemoveModifier(m_modifier2);//�Ƴ��޵�״̬
        playerCtrl.EnableMoveCtrl = true;//���ƶ����ƽ����ƶ�ģ��
    }
}
