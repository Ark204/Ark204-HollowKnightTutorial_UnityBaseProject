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
        GetComponentInChildren<Text>().text = InputManager.Instance.inputSystemDic[ChangingKey.name].ToString();  //��UI��ʾ
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
        while (true)  //�ȴ�����
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keycode))
                    {
                        ChangingKey.GetComponentInChildren<Text>().text = keycode.ToString();  //��UI��ʾ
                        InputManager.Instance.inputSystemDic[ChangingKey.transform.name].currKeyCode = keycode; //ͨ�����ָİ����ֵ�
                        //InputManager.GetInstance().inputSystemDic[ChangingKey.transform.name] = keycode; //ͨ�����ָİ����ֵ�
                        //InputManager.GetInstance().Show();
                    }
                    SumActive = false;
                }
                break;
            }
            yield return null;
        }
    }
}
