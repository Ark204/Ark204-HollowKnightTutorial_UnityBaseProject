using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

//设置移动相关
public class SetMove : BDele
{
    [SerializeField] float setGravity=0f;//想设置的重力尺度
    float saveGravity;//保存的重力尺度
    [SerializeField] bool useSpeed=false;//是否套用速度
    [SerializeField] float setSpeed;//想设置的水平移动速度
    float saveSpeed;//保存的水平移动速度
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.transform.Translate(new Vector3(0, 0.02f, 0)) ;
        saveGravity =rigidbody2D.gravityScale;//保存初始重力尺度
        rigidbody2D.gravityScale = setGravity;//设置重力尺度
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;//禁止Y轴移动
        //speed
        if (!useSpeed) return;
        var moveCtrl = skillManager.GetComponent<Core.Character.PlayerController>();
        saveSpeed=moveCtrl.speed;//保存原来的速度
        moveCtrl.speed = setSpeed;//设置新速度
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = saveGravity;//还原初始重力尺度
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;//还原Y轴移动
        //speed
        if (!useSpeed) return;
        var moveCtrl = skillManager.GetComponent<Core.Character.PlayerController>();
        moveCtrl.speed=saveSpeed;//恢复原来的速度
    }
}
