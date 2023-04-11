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

        //子元素自适应
        int screenHeight = Screen.height;
        int screenWidth = Screen.width;
        float referenceWidth = transform.GetComponentInParent<CanvasScaler>().referenceResolution.x;
        float referenceHeight = transform.GetComponentInParent<CanvasScaler>().referenceResolution.y;
        Vector3 objectScale = transform.parent.localScale;
        transform.parent.localScale = new Vector3(
               objectScale.x * referenceHeight / (float)screenHeight,
               objectScale.y * referenceWidth / (float)screenWidth,
               objectScale.z);
        //子元素生成
        for (int i = 0; i < n; i++)
        {
            ItemSlot itemSlot = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
            itemSlot.gameObject.transform.SetParent(instance.slotGrid.transform);
            itemSlot.item = infos[i].Item1;
            itemSlot.slotimage.sprite = infos[i].Item1.Icon;//直接赋值
            //itemSlot.slotimage.sprite = Sprite.Create(infos[i].Item1.Icon,
            //    new Rect(0, 0, infos[i].Item1.Icon.width, infos[i].Item1.Icon.height),
            //new Vector2(0.5f, 0.5f));
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
