using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//阻塞暂停UI
public class BlockUI : MonoBehaviour
{
    private static BlockUI currBlockUI=null;//当前正阻塞的UI

    private void OnEnable()
    {
        Time.timeScale = 0;//暂停游戏
        currBlockUI = this;//TODO:可以考虑合并至 UIBlocking{set}中
    }
    private void OnDisable()
    {
        Time.timeScale = 1;//恢复游戏
        currBlockUI = null;
    }
    //提供外部调用尝试打开
    public void OpenUI()
    {
        if (currBlockUI&&currBlockUI!=this) return;//已有别的UI打开，返回
        //BlockUI==this||currBlockUI=null
        gameObject.SetActive(!gameObject.activeSelf);//打开/关闭本UI
 
    }
}
