using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//地图节点
public class ScenePoint : MonoBehaviour
{
    [SerializeField] string sceneName;//场景名称
    [SerializeField] Color highLightColor=Color.red;//高亮颜色
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        if(sceneName==UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            image.color = highLightColor;//设置高亮
        }
    }
}
