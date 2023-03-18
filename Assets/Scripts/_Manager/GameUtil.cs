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
    //ɾ���浵���ݣ�ֻ������������ã�
    public void DeleteData()
    {
        BSaveData.DeleteAll();//����ɾ���浵����
    }
    //���ش浵����
    public void LoadData()
    {
        BSaveData.Load();//�������ش浵����
    }
    //����浵����
    public void SaveData()
    {
        BSaveData.Save();//������������
    }
    //�˳���Ϸ
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
