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
    [SerializeField] float m_lastCdTime;//剩余CD时间
    public float LastCdTime { get => m_lastCdTime; set { m_lastCdTime=value; } }
    public RSkillEntity(RSkillInfo info)
    {
        m_Info = info;
    }
}
[CreateAssetMenu(fileName ="RuntimeSkillData",menuName ="ScriptableObjct/运行时技能数据",order =0)]
public class RuntimeSkillCfg : BSaveData
{
    [SerializeField] List<RSkillEntity>  m_rSkillCfgs=new List<RSkillEntity>();
    Dictionary<int, RSkillEntity> m_rSkillCfgMap;
    //技能Id与技能数据组成的映射表
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
        if (m_rSkillCfgMap.ContainsKey(info.Id)) { Debug.Log("已有该技能，无法重复添加");  return; }
        var skillEntity = info.CreatEntity();
        m_rSkillCfgMap.Add(info.Id, skillEntity);//添加技能于表中
        m_rSkillCfgs.Add(skillEntity);//添加技能于数组中
    }

    public void SubCD(float time)
    {
        foreach (var elem in m_rSkillCfgMap)
        {
            if(elem.Value.LastCdTime>0) elem.Value.LastCdTime -= time;//若CD大于零，则减少CD
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
