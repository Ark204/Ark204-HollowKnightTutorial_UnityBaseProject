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
[CreateAssetMenu(fileName = "New PlayerInputSetting", menuName = "PlayerInputSetting")]
public class InputHandler :ScriptableObject
{
    [Header("Fight")]
    public List<KeyPair> keyPairs;
    [ContextMenu("Reset Setting")]
    public void ResetIps() //÷ÿ÷√◊÷µ‰ƒ⁄»›
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
            new KeyPair("subductionKey", KeyCode.W),
            new KeyPair("cycloneKey", KeyCode.E),
        };
    }
    private void OnEnable()
    {
        this.JosnLoad(name);
    }
    private void OnDestroy()
    {
        this.JosnSave(name, true);   
    }
}
