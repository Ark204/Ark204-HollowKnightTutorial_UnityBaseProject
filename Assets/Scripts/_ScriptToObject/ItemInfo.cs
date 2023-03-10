using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemInfo", menuName = "ScriptableObjct/物品数据", order = 0)]
public class ItemInfo : ScriptableObject
{
    [SerializeField] UnityEngine.UI.Image m_Icon;//图标
    [SerializeField] string describe;//物品描述
    public UnityEngine.UI.Image Icon { get => m_Icon; }
    public string Describe { get => describe; }
    public ItemEntity CreatEntity(uint count=1)
    {
        return new ItemEntity(this, count);
    }
}
[System.Serializable]public class ItemEntity
{
    [SerializeField] public uint count = 1;
    [SerializeField] ItemInfo m_Info;
    public ItemInfo ItemInfo { get => m_Info; }
    public ItemEntity(ItemInfo info, uint count = 1)
    {
        m_Info = info;
        this.count = count;
    }
}