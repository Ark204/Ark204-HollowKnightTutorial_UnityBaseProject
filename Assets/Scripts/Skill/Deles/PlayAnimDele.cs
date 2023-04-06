using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

//Trigger
public class PlayAnimDele : BDele
{
    [SerializeField] string animstr;
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        var animator = skillManager.GetComponentInChildren<Animator>();
        animator.SetTrigger(Animator.StringToHash(animstr));
    }
}
