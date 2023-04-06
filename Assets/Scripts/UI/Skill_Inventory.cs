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
    public GameObject myInventory;
   
    bool isOpen;

    [SerializeField] List<RSkillInfo> info;

    private void Update()
    {
        OpenInventory();
    }
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void OnEnable()
    {
        //Clear();
        //DataInit();
    }
    private void Start()
    {
        Clear();
        DataInit();

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
    public static void UpdateSkillInfo(string skilldescription)
    {
        instance.description.text = skilldescription;

    }
    void DataInit()
    {
        RSkillInfo[] infos = cfg.GetItems();
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

        int n = info.Count;
        for (int i = 0; i < n; i++)
        {
            Slot skillslot = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
            skillslot.gameObject.transform.SetParent(instance.slotGrid.transform);
            skillslot.skill = info[i];
            skillslot.slotimage.sprite = Sprite.Create(info[i].Icon,
                new Rect(0, 0, info[i].Icon.width, info[i].Icon.height),
            new Vector2(0.5f, 0.5f));
          
            

            if (i == 0)//默认选择第一个元素
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(skillslot.gameObject);
                skillslot.SkillOnClicked();
            }
        }
        n = infos.Length;
        for (int i = 0; i < n; i++)
        {
            Slot skillslot = Instantiate(instance.slot, instance.slotGrid.transform.position, Quaternion.identity);
            skillslot.gameObject.transform.SetParent(instance.slotGrid.transform);
            skillslot.skill = infos[i];
            skillslot.slotimage.sprite = Sprite.Create(infos[i].Icon,
                new Rect(0, 0, infos[i].Icon.width, infos[i].Icon.height),
            new Vector2(0.5f, 0.5f));
                   
        }
    }
    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                Clear();
                DataInit();
            }
            Time.timeScale = isOpen ? 0f : 1f;
            myInventory.SetActive(isOpen);
        }
    }

    
}
