using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class ChangeColorDele : BDele
{
    Color color;
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        color=skillManager.GetComponentInChildren<SpriteRenderer>().color ;
        skillManager.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponentInChildren<SpriteRenderer>().color = color;
    }
}
