using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconCool : MonoBehaviour
{
    Text lastCDtimeText;
    [SerializeField]Image cdOcclusion;
    [SerializeField] RuntimeSkillCfg m_runtimeSkillCfg;
    [SerializeField] int m_skillId;
    RSkillCfg skillCfg;//此UI对应的技能的数据
    private void Awake()
    {
        lastCDtimeText = GetComponentInChildren<Text>();
        //cdOcclusion = GetComponentInChildren<Image>();
        lastCDtimeText.gameObject.SetActive(false);
        skillCfg = m_runtimeSkillCfg.RSkillCfgMap[m_skillId];//从运行时技能数据表中获取对应ID的技能数据
    }
    private void Update()
    {
        if (skillCfg.LastCdTime>0)//cd时间>0 正在冷却中
        {
            lastCDtimeText.gameObject.SetActive(true);
            cdOcclusion.fillAmount =skillCfg.LastCdTime / skillCfg.CdTime;
            int show = (int)skillCfg.LastCdTime;
            lastCDtimeText.text = show.ToString();
        }
        else
        {
            lastCDtimeText.gameObject.SetActive(false);
        }
    }
}
