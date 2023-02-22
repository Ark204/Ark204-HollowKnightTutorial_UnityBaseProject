using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class RSkillCfg
{
    [SerializeField] int m_id;
    public int Id => m_id;
    [SerializeField] float m_cdTimee;
    public float CdTime => m_cdTimee;
    [SerializeField] float m_lastCdTime;
    public float LastCdTime { get => m_lastCdTime; set { m_lastCdTime=value; } }
}
[CreateAssetMenu(fileName ="RuntimeSkillData",menuName ="ScriptableObjct/运行时技能数据",order =0)]
public class RuntimeSkillCfg : ScriptableObject
{
    [SerializeField] List<RSkillCfg>  m_rSkillCfgs=new List<RSkillCfg>();
    Dictionary<int, RSkillCfg> m_rSkillCfgMap;
    //技能Id与技能数据组成的映射表
     public Dictionary<int, RSkillCfg> RSkillCfgMap
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
    void Init()
    {
        m_rSkillCfgMap = new Dictionary<int, RSkillCfg>();
        foreach (var elem in m_rSkillCfgs)
        {
            m_rSkillCfgMap.Add(elem.Id, elem);
        }
    }
    private void Awake()
    {
        Init();
    }
}
