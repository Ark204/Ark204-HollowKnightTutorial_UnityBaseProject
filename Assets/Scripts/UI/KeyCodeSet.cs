using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeSet : MonoBehaviour
{
    public GUIStyle style;
    public string tip;

    private bool SumActive;
    private bool once = false;
    private Button ChangingKey;
    private void Start()
    {
        ChangingKey = GetComponent<Button>();
        GetComponentInChildren<Text>().text = InputManager.Instance.inputSystemDic[ChangingKey.name].ToString();  //改UI显示
    }
    public void ActiveKeySave(Button this_button)
    {
        ChangingKey = this_button;
        SumActive = true;
        once = true;
    }

    private void OnGUI()
    {
        if (SumActive)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 200, 200), tip, style);
            if (once)
            {
                StartCoroutine(KeyGet());
                once = false;
            }
        }
    }

    IEnumerator KeyGet()
    {
        while (true)  //等待按键
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (keycode == KeyCode.Escape) continue;
                    if (Input.GetKeyDown(keycode))
                    {
                        bool hasKey = false;//是否已有该键，默认false->否
                        foreach (var elem in InputManager.Instance.inputSystemDic)//遍历每个按键
                        {
                            if (elem.Value.currKeyCode == keycode)
                            {
                                hasKey = true;
                                break;
                            }
                        }
                        if (!hasKey)//若该键不存在，则修改
                        {
                            ChangingKey.GetComponentInChildren<Text>().text = keycode.ToString();  //改UI显示
                            InputManager.Instance.inputSystemDic[ChangingKey.transform.name].currKeyCode = keycode; //通过名字改按键字典
                             //InputManager.GetInstance().inputSystemDic[ChangingKey.transform.name] = keycode; //通过名字改按键字典
                            //InputManager.GetInstance().Show();
                        }
                    }
                    SumActive = false;
                }
                break;
            }
            yield return null;
        }
    }
}
