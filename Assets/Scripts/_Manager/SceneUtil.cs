using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUtil : MonoSingleton<SceneUtil>
{
    public SaveScene saveScene;//保存的存档点

    protected override void Awake()
    {
        base.Awake();     
        DontDestroyOnLoad(this.gameObject);
    }
    //指定转移
    public void TransScene(string sceneName, int targetId)
    {
        StartCoroutine(Transition(sceneName, targetId));  
    }
    //回到存档点
    public void TransScene()
    {
        StartCoroutine(Transition(saveScene.sceneName, saveScene.targetId));
    }

    private IEnumerator Transition(string sceneName, int targetId)
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1f;//初始化时间尺度
        var player = GameObject.FindObjectOfType<PlayerCtrl>();
        var targets = GameObject.FindObjectsOfType<BTranslate>();
        foreach (var elem in targets)
        {
            if (elem.Id == targetId)
            {
                elem.Translate(player.gameObject);
                yield break;
            }
        }
        Debug.LogError("没有找到目的地");
    }
}
