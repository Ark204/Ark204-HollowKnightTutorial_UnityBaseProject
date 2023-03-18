using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BagInventory : MonoBehaviour
{
    static BagInventory instance;

    [SerializeField] Bag cfg;
    public GameObject slotGrid;
    public Text description;
    public ItemSlot slot;
    public static void UpdateItemInfo(string itemdescription)
    {
        instance.description.text = itemdescription;

    }
    //Normal
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        DataInit();//打开时初始化数据
    }
    private void OnDisable()
    {
        Clear();//关闭时清空数据
    }
    void Clear()
    {
        Transform transform;
        for (int i = 0; i < slotGrid.transform.childCount; i++)
        {
            transform = slotGrid.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }
    }
    void DataInit()
    {
        ValueTuple<ItemInfo, uint>[] infos = cfg.GetItems();
        int n = infos.Length;

        for (int i = 0; i < n; i++)
        {
            ItemSlot itemSlot = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
            itemSlot.gameObject.transform.SetParent(instance.slotGrid.transform);
            itemSlot.item = infos[i].Item1;
            itemSlot.slotimage.sprite = Sprite.Create(infos[i].Item1.Icon,
                new Rect(0, 0, infos[i].Item1.Icon.width, infos[i].Item1.Icon.height),
            new Vector2(0.5f, 0.5f));
            itemSlot.count.text = infos[i].Item2.ToString();
            if (i == 0)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(itemSlot.gameObject);

                itemSlot.ItemOnClicked();

            }
        }
    }
    //void OpenBag()
    //{
      
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        isOpen = !isOpen;
    //        if (isOpen)
    //        {
    //            Clear();
    //            DataInit();
    //        }
    //        Time.timeScale = isOpen ? 0f : 1f;
    //        myBag.SetActive(isOpen);
    //    }
    //}

}
