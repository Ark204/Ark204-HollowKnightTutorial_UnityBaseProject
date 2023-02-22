using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class PlayEffect : BDele
{
    [SerializeField] Vector3 offset;
    [SerializeField] float scale = 1;
    [SerializeField] Object attackEffect;
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        var player = skillManager.GetComponent<PlayerCtrl>();
        Vector3 center = new Vector3(skillManager.transform.localScale.x * offset.x + skillManager.transform.position.x, offset.y + skillManager.transform.position.y);;
        var effect = (GameObject)Instantiate(attackEffect, center, Quaternion.identity, skillManager.transform);//加载预制体//设为子物体
        effect.transform.localScale *= scale;
    }
}
