using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class LockY : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        playerCtrl.EnableMoveCtrl = false;//禁用移动模块
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;//禁止Y轴移动
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;//还原Y轴移动
        playerCtrl.EnableMoveCtrl = true;//将移动控制交还移动模块
    }
}
