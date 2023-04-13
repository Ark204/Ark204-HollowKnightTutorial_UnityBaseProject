using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]public class KeyPair
{
    public string keyName;
    public KeyCode currKeyCode;
    public  KeyPair(string keyName,KeyCode keyCode)
    {
       this.keyName = keyName;
        currKeyCode = keyCode;
    }
    public static implicit operator KeyCode (KeyPair keyPair)
    {
        return keyPair.currKeyCode;
    }
    public override string ToString()
    {
        return currKeyCode.ToString();
    }
}
//�������ã������ڴ浵������
[CreateAssetMenu(fileName = "New PlayerInputSetting", menuName = "PlayerInputSetting")]
public class InputHandler :ScriptableObject
{
    [Header("Fight")]
    public List<KeyPair> keyPairs;
    [ContextMenu("Reset Setting")]
    public void ResetIps() //�����ֵ�����
    {
        keyPairs = new List<KeyPair>()
        {
            new KeyPair("upKey", KeyCode.UpArrow),
            new KeyPair("downKey", KeyCode.DownArrow),
            new KeyPair("leftKey", KeyCode.LeftArrow),
            new KeyPair("rightKey", KeyCode.RightArrow),
            new KeyPair("jumpKey", KeyCode.D),
            new KeyPair("dashKey", KeyCode.Space),
            new KeyPair( "attackKey", KeyCode.A),
            new KeyPair( "upswingKey", KeyCode.Alpha2),
            //new KeyPair("subductionKey", KeyCode.W),�Ƴ�����
            new KeyPair("cycloneKey", KeyCode.E),
            new KeyPair("chopKey", KeyCode.R),
            new KeyPair("substituteKey", KeyCode.LeftShift),
            new KeyPair("bagKey", KeyCode.N),
            new KeyPair("skillMapKey", KeyCode.M),
            new KeyPair("mapKey", KeyCode.I),
        };
    }
    private void Awake()
    {
        if (PlayerPrefs.HasKey(name))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(name), this);
        }
        else
        {
            ResetIps();
        }
    }
    //private void OnEnable()
    //{
    //    this.JosnLoad(name);
    //}
    private void OnDestroy()
    {
        this.JosnSave(name, true);   
    }
    [ContextMenu("Save Setting")]
    public void JosnSave()
    {
        this.JosnSave(name, true);
    }
}
