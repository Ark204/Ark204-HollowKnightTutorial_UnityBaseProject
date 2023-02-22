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
    RSkillCfg skillCfg;//��UI��Ӧ�ļ��ܵ�����
    private void Awake()
    {
        lastCDtimeText = GetComponentInChildren<Text>();
        //cdOcclusion = GetComponentInChildren<Image>();
        lastCDtimeText.gameObject.SetActive(false);
        skillCfg = m_runtimeSkillCfg.RSkillCfgMap[m_skillId];//������ʱ�������ݱ��л�ȡ��ӦID�ļ�������
    }
    private void Update()
    {
        if (skillCfg.LastCdTime>0)//cdʱ��>0 ������ȴ��
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
