using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  RSkillInfo", menuName = "ScriptableObjct/技能数据", order = 0)]
public class RSkillInfo : ScriptableObject
{
    [SerializeField] Texture2D m_Icon;//图标
    [SerializeField] string describe;//物品描述
    public Texture2D Icon { get => m_Icon; }
    public string Describe { get => describe; }
    [SerializeField] int m_id;
    public int Id => m_id;//技能ID
    [SerializeField] int m_cdTimee;//技能CD
    public float CdTime => m_cdTimee;
    public RSkillEntity CreatEntity()
    {
        return new RSkillEntity(this);
    }
}
