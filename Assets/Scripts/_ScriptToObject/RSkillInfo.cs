using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  RSkillInfo", menuName = "ScriptableObjct/技能数据", order = 0)]
public class RSkillInfo : ScriptableObject
{
    [SerializeField] Sprite m_Icon;//图标
    [SerializeField] string displayName;//在UI上显示的名称
    [SerializeField][TextArea] string describe;//技能描述
    public Sprite Icon { get => m_Icon; }//图标
    public string DisplayName { get => displayName; }//名称
    public string Describe { get => describe; }//描述
    [SerializeField] int m_id;
    public int Id => m_id;//技能ID
    [SerializeField] float m_cdTimee;//技能CD
    public float CdTime => m_cdTimee;
    public RSkillEntity CreatEntity()
    {
        return new RSkillEntity(this);
    }
}
