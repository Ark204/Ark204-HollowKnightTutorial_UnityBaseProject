using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public InputHandler inputHandler;
    //[SerializeField] public  GameObject inputSetUI;
    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    private void Init()
    {
        if (inputHandler == null) { Debug.LogError("null inputHandler"); return; }
        if (inputSystemDic.Count==0)
        {
            foreach (var item in inputHandler.keyPairs)
            {
                inputSystemDic.Add(item.keyName, item);
            }
        }
    }
    public Dictionary<string,KeyPair> inputSystemDic=new Dictionary<string, KeyPair>();
    private void Update()
    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            if (inputSetUI.activeSelf == false) { inputSetUI.SetActive(true); Time.timeScale = 0; }
//            else 
//            {
//                inputHandler.JosnSave(inputHandler.name,true);
//                inputSetUI.SetActive(false); //关闭UI
//                Time.timeScale = 1; //还原时间尺度
//            }
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha6))
//        {
//#if UNITY__EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#endif
//            Application.Quit();
//        }
    }
    //GetAxis
    public static float GetAxisRaw(string axisName)
    {
        float axis=0f;
        if(axisName== "Horizontal")
        {
            if (Input.GetKey(Instance.inputSystemDic["leftKey"])) axis = -1f;
            else if (Input.GetKey(Instance.inputSystemDic["rightKey"])) axis = 1f;
            else axis = 0f;
        }
        else if(axisName== "Vertical")
        {
            if (Input.GetKey(Instance.inputSystemDic["downKey"])) axis = -1f;
            else if (Input.GetKey(Instance.inputSystemDic["upKey"])) axis = 1f;
            else axis = 0f;
        }
        return axis;
    }
}
