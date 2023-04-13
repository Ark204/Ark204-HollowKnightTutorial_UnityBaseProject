using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Text healthText;
    Image healthSlider;
    [SerializeField] PlayerData playerData;//主角数据
    [SerializeField] RuntimeSkillCfg cfg;//技能表
    [SerializeField] HorizontalLayoutGroup group;

    private void Awake()
    {
        //血条UI相关组件获取
        healthText = transform.GetChild(1).GetComponent<Text>();
        healthSlider = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        RefreshSkill();//初始化技能栏
        cfg.OnSkillAdd += RefreshSkill;//添加对技能增加事件的监听
    }
    private void OnDestroy()
    {
        cfg.OnSkillAdd -= RefreshSkill;//移除监听
    }

    private void Update()
    {
        healthText.text = playerData.HP + "/" + playerData.MaxHp;
        float sliderPercent = (float)playerData.HP / playerData.MaxHp;
        healthSlider.fillAmount = sliderPercent;
    }
    //重新渲染技能栏UI
    void RefreshSkill()
    {
        SkillIconCool[] skillIconCools=group.GetComponentsInChildren<SkillIconCool>(true);//获取子元素列表
        int i = 0;
        foreach(var elem in cfg.RSkillCfgMap)
        {
            skillIconCools[i].RSkillEntity = elem.Value;//设置技能信息
            i++;
        }
        for(; i<skillIconCools.Length;i++ )
        {
            skillIconCools[i].RSkillEntity = null;//设置空
        }
    }

}
