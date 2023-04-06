using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class Upswing : BDele
{
    [SerializeField] float upForce = 60;
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        //PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        //playerCtrl.EnableMoveCtrl = false;//禁用移动模块
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(0, upForce)) ;//设置速度
        //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, upForce);
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        //PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
       // Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        //behaviorCtrl.modifierAcceptor.RemoveModifier(m_modifier2);//移除无敌状态
        //playerCtrl.EnableMoveCtrl = true;//将移动控制交还移动模块
    }
}
