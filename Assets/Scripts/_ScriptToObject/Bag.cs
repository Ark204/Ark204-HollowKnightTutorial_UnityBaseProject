using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Bag", menuName = "玩家背包", order = 0)]
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
    //查找物品
    public uint FindItem(ItemInfo info)
    {
        foreach(var item in items)
        {
            if (item.ItemInfo == info) return item.count;
        }
        return 0;
    }
    //增加物品
    public void AddItem(ItemInfo info,uint count)
    {
        foreach(var item in items)
        {
            if (item.ItemInfo == info) { item.count += count; return; }//TODO:最大值判定
        }
        //找不到Item
        ItemEntity newItem = new ItemEntity(info, count);//创建新的ItemEntity
        items.Add(newItem);//添加进背包
    }
    public void AddItem(ItemInfo info, int count) { AddItem(info, (uint)count); }
    //减少物品
    public bool SubItem(ItemInfo info,uint count)
    {
        foreach(var item in items)
        {
            if(item.ItemInfo==info) 
            {
                if (item.count < count) return false;//不够
                item.count -= count;return true; 
            }
        }
        return false;//找不到
    }
    protected override void OnLoad()
    {
        //读取磁盘数据
        if (PlayerPrefs.HasKey(this.name))
        {
            items = JsonUtility.FromJson<Bag>(PlayerPrefs.GetString(this.name)).items;
        }
        else
        {
            items = new List<ItemEntity>();
        }
    }

    protected override void OnSave() { }
    protected override KeyValuePair<string, string> GetSaveString()
    {
        return new KeyValuePair<string, string>(this.name, JsonUtility.ToJson(this, true));
    }
}
