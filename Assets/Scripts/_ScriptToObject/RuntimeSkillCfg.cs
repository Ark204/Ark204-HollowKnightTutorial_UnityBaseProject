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
    [System.NonSerialized] Dictionary<int, RSkillEntity> m_rSkillCfgMap;
     [SerializeField] List<RSkillInfo> defaultInfo;//�Դ���Ĭ�ϳ�ʼ����    
    public event System.Action OnSkillAdd;//�������ʱ�����¼� 
    //����Id�뼼��������ɵ�ӳ�������ʱ���ݡ��ӳٳ�ʼ����
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
        foreach(var pair in RSkillCfgMap)//�����ֵ�
        {
            ps[i] = pair.Value.RSkillInfo;//�������߼���Ϣ����
            i++;//index����
        }
        return ps;
    }

    public void AddSkill(RSkillInfo info)
    {
        if (RSkillCfgMap.ContainsKey(info.Id)) { Debug.Log("���иü��ܣ��޷��ظ����");  return; }
        var skillEntity = info.CreatEntity();
        RSkillCfgMap.Add(info.Id, skillEntity);//��Ӽ����ڱ���
        m_rSkillCfgs.Add(skillEntity);//��Ӽ�����������
        //�����¼�
        OnSkillAdd?.Invoke();
    }

    public void SubCD(float time)
    {
        foreach (var elem in RSkillCfgMap)
        {
            if(elem.Value.LastCdTime>0) elem.Value.LastCdTime -= time;//��CD�����㣬�����CD
        }
    }
    void Init()//��ʼ�����ܱ�
    {
        m_rSkillCfgMap = new Dictionary<int, RSkillEntity>();
        foreach (var elem in m_rSkillCfgs)
        {
            m_rSkillCfgMap.Add(elem.Id, elem);
        }
    }

    protected override void OnSave() { }//��ʼ�� 

    protected override void OnLoad() 
    {
        //��ȡ��������
        if (PlayerPrefs.HasKey(this.name))
        {
            //�Ӵ��̶�ȡ�����б�
            //JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(this.name),this);
            m_rSkillCfgs = JsonUtility.FromJson<SerializationList<RSkillEntity>>(PlayerPrefs.GetString(this.name)).ToList();
        }
        else//�յ�
        {
            m_rSkillCfgs = new List<RSkillEntity>();//�������б�
            RSkillCfgMap.Clear();//��ձ�
            //���Ĭ�ϳ�ʼ����
            foreach (var elem in defaultInfo)
            {
                AddSkill(elem);//���
            }
        }
    }

    protected override KeyValuePair<string, string> GetSaveString()
    {
        // return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(this, true));
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(new SerializationList<RSkillEntity>(m_rSkillCfgs), true));
    }
}
