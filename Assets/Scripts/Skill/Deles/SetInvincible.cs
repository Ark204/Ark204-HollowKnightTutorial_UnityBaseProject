using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

//�����޵�
public class SetInvincible : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        skillManager.GetComponent<PlayerCtrl>().CanBeHit = false;//ʹ���ǲ��ܱ�����
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        Physics2D.IgnoreLayerCollision(6, 8,false);
        skillManager.GetComponent<PlayerCtrl>().CanBeHit = true;//ʹ���ǿ��Ա�����
    }
}
