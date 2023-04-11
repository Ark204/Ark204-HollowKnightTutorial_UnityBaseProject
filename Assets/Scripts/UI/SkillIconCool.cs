using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconCool : MonoBehaviour
{
    Text lastCDtimeText;
    [SerializeField]Image cdOcclusion;
    [SerializeField] Material falshMaterial;//刷新时材质
    Material dafultMaterial;//默认材质
    //[SerializeField] RuntimeSkillCfg m_runtimeSkillCfg;
    //[SerializeField] int m_skillId;
    Image image;
     RSkillEntity skillCfg=null;//此UI对应的技能的数据
    public RSkillEntity RSkillEntity { set
        {
            gameObject.SetActive(value!=null);//SetActive-->gameObject||this
            skillCfg = value;//设置数据
            if (value == null) return;
            //设置图标
            var texture = value.Icon;
            image.sprite = texture;
            //   image.sprite = Sprite.Create(texture,
            //    new Rect(0, 0, texture.width, texture.height),
            //new Vector2(0.5f, 0.5f));
        } }
    private void Awake()
    {
        lastCDtimeText = GetComponentInChildren<Text>();
        image = GetComponent<Image>();//获取自身图标Image
        dafultMaterial = image.material;//保存默认材质
        //cdOcclusion = GetComponentInChildren<Image>();拖拽获取
        lastCDtimeText.gameObject.SetActive(false);
        //skillCfg = m_runtimeSkillCfg.RSkillCfgMap[m_skillId];//从运行时技能数据表中获取对应ID的技能数据
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
        else if(lastCDtimeText.gameObject.activeSelf)//否则若CD图标仍活跃
        {
            //刷新闪烁
            image.material = falshMaterial;//设置为刷新材质
            StartCoroutine(TQueueExtion.DelayFunc(()=> { image.material = dafultMaterial; },0.1f));//重置材质
            //结束CD相关渲染
            cdOcclusion.fillAmount = 0;
            lastCDtimeText.gameObject.SetActive(false);//关闭
        }
    }
}
