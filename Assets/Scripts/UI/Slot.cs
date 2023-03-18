using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, ISelectHandler
{
    public RSkillInfo skill;
    public Image slotimage;
    
    public void OnSelect(BaseEventData eventData)
    {
        SkillOnClicked();
    }
    public void SkillOnClicked()
    {
        string allinfo = "技能名称 ：" + skill.DisplayName + '\n' + "技能介绍 ：" +  skill.Describe + '\n' + "CD :" + skill.CdTime;
        Skill_Inventory.UpdateSkillInfo(allinfo);
    }
}
