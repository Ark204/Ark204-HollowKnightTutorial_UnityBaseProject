using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Text healthText;
    Image healthSlider;
    [SerializeField] PlayerData playerData;//��������
    [SerializeField] RuntimeSkillCfg cfg;//���ܱ�
    [SerializeField] HorizontalLayoutGroup group;

    private void Awake()
    {
        //Ѫ��UI��������ȡ
        healthText = transform.GetChild(1).GetComponent<Text>();
        healthSlider = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        RefreshSkill();//��ʼ��������
        cfg.OnSkillAdd += RefreshSkill;//��ӶԼ��������¼��ļ���
    }
    private void OnDestroy()
    {
        cfg.OnSkillAdd -= RefreshSkill;//�Ƴ�����
    }

    private void Update()
    {
        healthText.text = playerData.HP + "/" + playerData.MaxHp;
        float sliderPercent = (float)playerData.HP / playerData.MaxHp;
        healthSlider.fillAmount = sliderPercent;
    }
    //������Ⱦ������UI
    void RefreshSkill()
    {
        SkillIconCool[] skillIconCools=group.GetComponentsInChildren<SkillIconCool>(true);//��ȡ��Ԫ���б�
        int i = 0;
        foreach(var elem in cfg.RSkillCfgMap)
        {
            skillIconCools[i].RSkillEntity = elem.Value;//���ü�����Ϣ
            i++;
        }
        for(; i<skillIconCools.Length;i++ )
        {
            skillIconCools[i].RSkillEntity = null;//���ÿ�
        }
    }

}
