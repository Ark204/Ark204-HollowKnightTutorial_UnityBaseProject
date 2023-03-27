using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class ChangeColorDele : BDele
{
    [SerializeField] Color targetColor;//Ŀ��ת������ɫ
    // Color color;//�������ɫ
    //public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    //{
    //    var render = skillManager.GetComponentInChildren<SpriteRenderer>();
    //    color =render.color ;//������ɫ
    //    render.color = targetColor;//��Ϊ��ɫ
    //}
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponentInChildren<SpriteRenderer>().color = targetColor;//�ָ���ɫ
    }
}
