using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  RSkillInfo", menuName = "ScriptableObjct/��������", order = 0)]
public class RSkillInfo : ScriptableObject
{
    [SerializeField] Texture2D m_Icon;//ͼ��
    [SerializeField] string describe;//��Ʒ����
    public Texture2D Icon { get => m_Icon; }
    public string Describe { get => describe; }
    [SerializeField] int m_id;
    public int Id => m_id;//����ID
    [SerializeField] int m_cdTimee;//����CD
    public float CdTime => m_cdTimee;
    public RSkillEntity CreatEntity()
    {
        return new RSkillEntity(this);
    }
}
