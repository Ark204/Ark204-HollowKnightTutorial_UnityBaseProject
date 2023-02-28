using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class RSkillEntity
{
    [SerializeField] RSkillInfo m_Info;
    public RSkillInfo RSkillInfo { get => m_Info; }
    public Texture2D Icon { get => m_Info.Icon; }
    public string Describe { get => m_Info.Describe; }
    public int Id => m_Info.Id;
    public float CdTime => m_Info.CdTime;
    [SerializeField] float m_lastCdTime;//ʣ��CDʱ��
    public float LastCdTime { get => m_lastCdTime; set { m_lastCdTime=value; } }
    public RSkillEntity(RSkillInfo info)
    {
        m_Info = info;
    }
}
[CreateAssetMenu(fileName ="RuntimeSkillData",menuName ="ScriptableObjct/����ʱ��������",order =0)]
public class RuntimeSkillCfg : BSaveData
{
    [SerializeField] List<RSkillEntity>  m_rSkillCfgs=new List<RSkillEntity>();
    Dictionary<int, RSkillEntity> m_rSkillCfgMap;
    //����Id�뼼��������ɵ�ӳ���
     public Dictionary<int, RSkillEntity> RSkillCfgMap
    {
        get
        {
            if(m_rSkillCfgMap==null)
            {
                Init();
            }
            return m_rSkillCfgMap;
        }
    }

    public void AddSkill(RSkillInfo info)
    {
        if (m_rSkillCfgMap.ContainsKey(info.Id)) { Debug.Log("���иü��ܣ��޷��ظ����");  return; }
        var skillEntity = info.CreatEntity();
        m_rSkillCfgMap.Add(info.Id, skillEntity);//��Ӽ����ڱ���
        m_rSkillCfgs.Add(skillEntity);//��Ӽ�����������
    }

    public void SubCD(float time)
    {
        foreach (var elem in m_rSkillCfgMap)
        {
            if(elem.Value.LastCdTime>0) elem.Value.LastCdTime -= time;//��CD�����㣬�����CD
        }
    }
    void Init()
    {
        m_rSkillCfgMap = new Dictionary<int, RSkillEntity>();
        foreach (var elem in m_rSkillCfgs)
        {
            m_rSkillCfgMap.Add(elem.Id, elem);
        }
    }
    private void Awake()
    {
        Init();
    }

    protected override void OnSave() { }

    protected override void OnLoad() { }
}
