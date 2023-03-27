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
    [System.NonSerialized] Dictionary<int, RSkillEntity> m_rSkillCfgMap;
     [SerializeField] List<RSkillInfo> defaultInfo;//自带的默认初始技能    
    public event System.Action OnSkillAdd;//技能添加时触发事件 
    //技能Id与技能数据组成的映射表（运行时数据、延迟初始化）
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

    public RSkillInfo[] GetItems()
    {
        RSkillInfo[] ps = new RSkillInfo[RSkillCfgMap.Count];
        int i = 0;
        foreach(var pair in RSkillCfgMap)//遍历字典
        {
            ps[i] = pair.Value.RSkillInfo;//将技能逻辑信息赋予
            i++;//index增加
        }
        return ps;
    }

    public void AddSkill(RSkillInfo info)
    {
        if (RSkillCfgMap.ContainsKey(info.Id)) { Debug.Log("已有该技能，无法重复添加");  return; }
        var skillEntity = info.CreatEntity();
        RSkillCfgMap.Add(info.Id, skillEntity);//添加技能于表中
        m_rSkillCfgs.Add(skillEntity);//添加技能于数组中
        //触发事件
        OnSkillAdd?.Invoke();
    }

    public void SubCD(float time)
    {
        foreach (var elem in RSkillCfgMap)
        {
            if(elem.Value.LastCdTime>0) elem.Value.LastCdTime -= time;//若CD大于零，则减少CD
        }
    }
    void Init()//初始化技能表
    {
        m_rSkillCfgMap = new Dictionary<int, RSkillEntity>();
        foreach (var elem in m_rSkillCfgs)
        {
            m_rSkillCfgMap.Add(elem.Id, elem);
        }
    }

    protected override void OnSave() { }//初始化 

    protected override void OnLoad() 
    {
        //读取磁盘数据
        if (PlayerPrefs.HasKey(this.name))
        {
            //从磁盘读取技能列表
            //JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(this.name),this);
            m_rSkillCfgs = JsonUtility.FromJson<SerializationList<RSkillEntity>>(PlayerPrefs.GetString(this.name)).ToList();
        }
        else//空档
        {
            m_rSkillCfgs = new List<RSkillEntity>();//创建空列表
            RSkillCfgMap.Clear();//清空表
            //添加默认初始技能
            foreach (var elem in defaultInfo)
            {
                AddSkill(elem);//添加
            }
        }
    }

    protected override KeyValuePair<string, string> GetSaveString()
    {
        // return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(this, true));
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(new SerializationList<RSkillEntity>(m_rSkillCfgs), true));
    }
}
