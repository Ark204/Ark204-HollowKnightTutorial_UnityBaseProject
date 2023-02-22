using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class Substitute : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponent<PlayerCtrl>().Substitute = true;//ʹ���ǽ���������״̬
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponent<PlayerCtrl>().Substitute = false;//ʹ�����Ƴ�������״̬
    }
}   
