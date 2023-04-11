using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIconCool : MonoBehaviour
{
    Text lastCDtimeText;
    [SerializeField]Image cdOcclusion;
    [SerializeField] Material falshMaterial;//ˢ��ʱ����
    Material dafultMaterial;//Ĭ�ϲ���
    //[SerializeField] RuntimeSkillCfg m_runtimeSkillCfg;
    //[SerializeField] int m_skillId;
    Image image;
     RSkillEntity skillCfg=null;//��UI��Ӧ�ļ��ܵ�����
    public RSkillEntity RSkillEntity { set
        {
            gameObject.SetActive(value!=null);//SetActive-->gameObject||this
            skillCfg = value;//��������
            if (value == null) return;
            //����ͼ��
            var texture = value.Icon;
            image.sprite = texture;
            //   image.sprite = Sprite.Create(texture,
            //    new Rect(0, 0, texture.width, texture.height),
            //new Vector2(0.5f, 0.5f));
        } }
    private void Awake()
    {
        lastCDtimeText = GetComponentInChildren<Text>();
        image = GetComponent<Image>();//��ȡ����ͼ��Image
        dafultMaterial = image.material;//����Ĭ�ϲ���
        //cdOcclusion = GetComponentInChildren<Image>();��ק��ȡ
        lastCDtimeText.gameObject.SetActive(false);
        //skillCfg = m_runtimeSkillCfg.RSkillCfgMap[m_skillId];//������ʱ�������ݱ��л�ȡ��ӦID�ļ�������
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
        else if(lastCDtimeText.gameObject.activeSelf)//������CDͼ���Ի�Ծ
        {
            //ˢ����˸
            image.material = falshMaterial;//����Ϊˢ�²���
            StartCoroutine(TQueueExtion.DelayFunc(()=> { image.material = dafultMaterial; },0.1f));//���ò���
            //����CD�����Ⱦ
            cdOcclusion.fillAmount = 0;
            lastCDtimeText.gameObject.SetActive(false);//�ر�
        }
    }
}
