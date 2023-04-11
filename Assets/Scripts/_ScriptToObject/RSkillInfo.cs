using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  RSkillInfo", menuName = "ScriptableObjct/��������", order = 0)]
public class RSkillInfo : ScriptableObject
{
    [SerializeField] Sprite m_Icon;//ͼ��
    [SerializeField] string displayName;//��UI����ʾ������
    [SerializeField][TextArea] string describe;//��������
    public Sprite Icon { get => m_Icon; }//ͼ��
    public string DisplayName { get => displayName; }//����
    public string Describe { get => describe; }//����
    [SerializeField] int m_id;
    public int Id => m_id;//����ID
    [SerializeField] float m_cdTimee;//����CD
    public float CdTime => m_cdTimee;
    public RSkillEntity CreatEntity()
    {
        return new RSkillEntity(this);
    }
}
