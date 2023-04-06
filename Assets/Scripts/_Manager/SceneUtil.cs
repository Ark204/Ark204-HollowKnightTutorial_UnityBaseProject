using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUtil : MonoSingleton<SceneUtil>
{
    public SaveScene saveScene;//保存的存档点
    Animator panl;//过场画布
    protected override void Awake()
    {
        base.Awake();     
        DontDestroyOnLoad(this.gameObject);
       
    }
    private void Start()
    {
        if (panl == null) panl = GetComponentInChildren<Animator>();//获取过场画布
    }
    //返回主菜单
    public void MainMenu()
    {
        StartCoroutine(GoMainMenu());
    }
    //指定转移
    public void TransScene(string sceneName, int targetId)
    {
        StartCoroutine(Transition(sceneName, targetId));  
    }
    //回到存档点
    public void TransScene()
    {
        //GetComponentInChildren<Animator>(true).gameObject.SetActive
        StartCoroutine(Transition(saveScene.sceneName, saveScene.targetId));
    }

    private IEnumerator Transition(string sceneName, int targetId)
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu") panl.Play("Player");
        else panl?.Play("FadeIn");//gameObject.SetActive(true);//开过场动画
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1f;//初始化时间尺度
        var player = GameObject.FindObjectOfType<PlayerCtrl>();
        var targets = GameObject.FindObjectsOfType<BTranslate>();
        foreach (var elem in targets)
        {
            if (elem.Id == targetId)
            {
                elem.Translate(player.gameObject);
                //yield return new WaitForSecondsRealtime(1.5f);强制动画
                panl?.Play("FadeOut");//gameObject.SetActive(false);//结束过场动画
                yield break;
            }
        }
        Debug.LogError("没有找到目的地");
    }
    IEnumerator GoMainMenu()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1f;//初始化时间尺度
    }
}
