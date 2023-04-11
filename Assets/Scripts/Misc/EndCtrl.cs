using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCtrl : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Animator anim;
    [SerializeField] [TextArea] List<string> tests;//�ı��б�
    public int currIndex = 0;
    public void ChangeText(string str)
    {
        text.text = str;
    }
    public void ChangeScene() 
    {
        SceneUtil.Instance.MainMenu();
    }
    public void ChangeTextV()
    {
        if (currIndex >= tests.Count) { anim.Play("Maker"); return; }
        text.text = tests[currIndex];
        currIndex++;//��Index
    }
    public void ChangeTextI(int i)
    {
        text.text = tests[i];
    }
}
