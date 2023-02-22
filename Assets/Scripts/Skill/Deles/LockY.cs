using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class LockY : BDele
{
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        playerCtrl.EnableMoveCtrl = false;//�����ƶ�ģ��
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;//��ֹY���ƶ�
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        PlayerCtrl playerCtrl = skillManager.GetComponent<PlayerCtrl>();
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;//��ԭY���ƶ�
        playerCtrl.EnableMoveCtrl = true;//���ƶ����ƽ����ƶ�ģ��
    }
}
