using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ItemSlot : MonoBehaviour, ISelectHandler
{
    public ItemInfo item;
    public Image slotimage;
    public Text count;

    public void OnSelect(BaseEventData eventData)
    {
        ItemOnClicked();
    }
    public void ItemOnClicked()
    {
        
        BagInventory.UpdateItemInfo(item.Describe);
    }
}
