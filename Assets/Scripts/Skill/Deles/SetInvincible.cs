using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

//设置无敌
public class SetInvincible : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        skillManager.GetComponent<PlayerCtrl>().CanBeHit = false;//使主角不能被命中
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        Physics2D.IgnoreLayerCollision(6, 8,false);
        skillManager.GetComponent<PlayerCtrl>().CanBeHit = true;//使主角可以被命中
    }
}
