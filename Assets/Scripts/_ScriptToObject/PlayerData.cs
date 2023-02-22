using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjct/玩家数据", order = 0)]
public class PlayerData:BSaveData
{
    [System.Serializable]struct SaveData
    {
        public int maxHp;
        public int maxEnerge;
        //攻击力
        public float attackPower ;
        public SaveData(int Hp,int Energe,int attack)
        {
            maxHp = Hp;
            maxEnerge = Energe;
            attackPower = attack;
        }
    }
    [SerializeField] SaveData m_saveData = new SaveData(50, 10, 1);
    public int HP=5;
    public int MaxHp { get => m_saveData.maxHp; set { m_saveData.maxHp = value; } }
    public int Energe=0;
    public int MaxEnerge { get => m_saveData.maxEnerge; set { m_saveData.maxEnerge = value; } }
    //AttackData
    public float AttackPower { get => m_saveData.attackPower; set { m_saveData.attackPower = value; } }

    //消息：外部调用存储时调用
    protected override void OnSave()
    {
        HP = MaxHp;
    }
    protected override void OnLoad()
    {   //读取磁盘数据
        if (PlayerPrefs.HasKey(this.name))
        {
            m_saveData=JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(this.name));
        }
        else
        {
            m_saveData = new SaveData(5, 10, 1);
        }
        //数据初始化
        HP = MaxHp;
        Energe = 0;
    }
    protected override KeyValuePair<string,string> GetSaveString()
    {
        return  new KeyValuePair<string,string>( this.name,JsonUtility.ToJson(m_saveData, true));
    }
}