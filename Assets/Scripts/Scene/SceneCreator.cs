using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//场景物体生成器，只负责场景加载时的判定生成生成
public class SceneCreator : MonoBehaviour
{
    [SerializeField] int index;//索引
    [SerializeField] bool target = true;//目标列表
    [SerializeField] List<Object> OnFalse;//false时的生成物
    [SerializeField] List<Object> OnTrue;//true时的生成物
    private void Awake()
    {
        //if(DataManager.Instance.m_saveData.GetBool(index))
        //{
        //    foreach(var elem in OnFalse) 
        //        game=Instantiate(elem, transform) as GameObject;//生成物体，且列为子物体
        //}
        //else
        //{
        //    foreach (var elem in OnTrue)
        //        game = Instantiate(elem, transform) as GameObject;//生成物体，且列为子物体
        //}
    }
    private void Start()
    {
        if (DataManager.Instance.m_saveData.GetBool(index,target)==false)
        {
            GameObject game;
            foreach (var elem in OnFalse)
                game = Instantiate(elem, transform) as GameObject;//生成物体，且列为子物体
        }
        else
        {
            GameObject game;
            foreach (var elem in OnTrue)
                game = Instantiate(elem, transform) as GameObject;//生成物体，且列为子物体
        }
    }
}
