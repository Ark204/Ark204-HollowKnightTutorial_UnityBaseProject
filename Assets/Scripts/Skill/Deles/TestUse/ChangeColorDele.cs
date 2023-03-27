using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

public class ChangeColorDele : BDele
{
    [SerializeField] Color targetColor;//目标转换的颜色
    // Color color;//保存的颜色
    //public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    //{
    //    var render = skillManager.GetComponentInChildren<SpriteRenderer>();
    //    color =render.color ;//保存颜色
    //    render.color = targetColor;//设为红色
    //}
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        skillManager.GetComponentInChildren<SpriteRenderer>().color = targetColor;//恢复颜色
    }
}
