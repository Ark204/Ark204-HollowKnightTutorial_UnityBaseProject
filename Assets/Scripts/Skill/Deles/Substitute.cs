using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class Substitute : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponent<PlayerCtrl>().Substitute = true;//使主角进入替身术状态
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponent<PlayerCtrl>().Substitute = false;//使主角移除替身术状态
    }
}   
