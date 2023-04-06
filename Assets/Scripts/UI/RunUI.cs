using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏内容进行时对所有UI的管理
public class RunUI : MonoBehaviour
{
    public BlockUI gameMenu;//游戏内菜单
    public BlockUI bag;//背包
    public BlockUI skill;//技能表
    public BlockUI Map;//地图
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) gameMenu.OpenUI();//打开游戏内菜单
        if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["bagKey"])) bag.OpenUI();
        if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["skillMapKey"])) skill.OpenUI();
        if (Input.GetKeyDown(InputManager.Instance.inputSystemDic["mapKey"])) Map.OpenUI();//打开游戏内菜单
    }
}
