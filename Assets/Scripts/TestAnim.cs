using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour
{
    [SerializeField]UnityArmatureComponent unityArmature;
    [SerializeField]public string nameAnim;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var elem in   unityArmature._armature.armatureData.animations)
        {
            Debug.Log(elem.Value.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)){ unityArmature.animation.Play(nameAnim); unityArmature.animation.timeScale = 9; }
        
    }
}
