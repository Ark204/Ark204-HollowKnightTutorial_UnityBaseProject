using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Skill_Inventory : MonoBehaviour 
{
    static Skill_Inventory instance;

    [SerializeField] RuntimeSkillCfg cfg;
    public GameObject slotGrid;
    public Text description;
    public Slot slot;
    //由Slot调用更新描述
    public static void UpdateSkillInfo(string skilldescription)
    {
        instance.description.text = skilldescription;
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
        RSkillInfo[] infos = cfg.GetItems();
        int n = infos.Length;

        for (int i = 0; i < n; i++)
        {
            Slot skillslot = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
            skillslot.gameObject.transform.SetParent(instance.slotGrid.transform);
            skillslot.skill = infos[i];
            skillslot.slotimage.sprite = Sprite.Create(infos[i].Icon,
                new Rect(0, 0, infos[i].Icon.width, infos[i].Icon.height),
            new Vector2(0.5f, 0.5f));
            if (i == 0)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(skillslot.gameObject);

                skillslot.SkillOnClicked();
               
            }
        }
    }
    //void OpenInventory()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        isOpen = !isOpen;
    //        if(isOpen)
    //        {
    //            Clear();
    //            DataInit();
    //        }
    //        Time.timeScale = isOpen ? 0f : 1f;
    //        myInventory.SetActive(isOpen);
    //    }
    //}
}
