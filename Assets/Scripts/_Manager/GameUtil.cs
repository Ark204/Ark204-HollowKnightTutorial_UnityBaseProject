using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUtil", menuName = "ScriptableObjct/GameUtil", order = 0)]
public class GameUtil : ScriptableObject
{
    public void ExeTest(int s)
    {
        Debug.Log(s);
    }
    //删除存档数据（只能在主界面调用）
    public void DeleteData()
    {
        BSaveData.DeleteAll();//遍历删除存档数据
    }
    //加载存档数据
    public void LoadData()
    {
        BSaveData.Load();//遍历加载存档数据
    }
    //保存存档数据
    public void SaveData()
    {
        BSaveData.Save();//遍历保存数据
    }
    //退出游戏
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
