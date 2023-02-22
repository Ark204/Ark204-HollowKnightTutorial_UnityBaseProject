using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjct/���̱�������", order = 0)]
public class SaveData : BSaveData
{
    public List<bool> bools = new List<bool>();
    //����ʱ���ô˺���
    protected override void OnSave()
    {
        for(int i=0;i<bools.Count;i++)
        {
            bools[i] = true;
        }
    }
    //����ʱ���ô˺���
    protected override void OnLoad()
    {
        for (int i = 0; i < bools.Count; i++)
        {
            bools[i] = true;
        }
    }
}
