using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Bag", menuName = "��ұ���", order = 0)]
public class Bag : BSaveData
{
    [SerializeField]List<ItemEntity> items=new List<ItemEntity>();
    public ValueTuple<ItemInfo,uint>[] GetItems()
    {
        ValueTuple<ItemInfo, uint>[] ps = new ValueTuple<ItemInfo, uint>[items.Count];
        for(int i=0;i<items.Count;i++)
        {
            ps[i] = new ValueTuple<ItemInfo, uint>(items[i].ItemInfo, items[i].count);
        }
        return ps;
    }
    //������Ʒ
    public uint FindItem(ItemInfo info)
    {
        foreach(var item in items)
        {
            if (item.ItemInfo == info) return item.count;
        }
        return 0;
    }
    //������Ʒ
    public void AddItem(ItemInfo info,uint count)
    {
        foreach(var item in items)
        {
            if (item.ItemInfo == info) { item.count += count; return; }//TODO:���ֵ�ж�
        }
        //�Ҳ���Item
        ItemEntity newItem = new ItemEntity(info, count);//�����µ�ItemEntity
        items.Add(newItem);//��ӽ�����
    }
    public void AddItem(ItemInfo info, int count) { AddItem(info, (uint)count); }
    //������Ʒ
    public bool SubItem(ItemInfo info,uint count)
    {
        foreach(var item in items)
        {
            if(item.ItemInfo==info) 
            {
                if (item.count < count) return false;//����
                item.count -= count;return true; 
            }
        }
        return false;//�Ҳ���
    }
    //Save About
    protected override void OnLoad()
    {
        //��ȡ��������
        if (PlayerPrefs.HasKey(this.name))
        {
            //�����л���List
            items=JsonUtility.FromJson<SerializationList<ItemEntity>>(PlayerPrefs.GetString(this.name)).ToList();
        }
        else//�յ�
        {
            items = new List<ItemEntity>();//�������б�
        }
    }

    protected override void OnSave() { }
    protected override KeyValuePair<string, string> GetSaveString()
    {
        //�洢�б�
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(new SerializationList<ItemEntity>(items), true));
    }
}

public class SerializationList<T>
{
    [SerializeField] List<T> targetList;
    public List<T> ToList (){ return targetList; }
    public SerializationList(List<T> target)
    {
        targetList = target;
    }

}