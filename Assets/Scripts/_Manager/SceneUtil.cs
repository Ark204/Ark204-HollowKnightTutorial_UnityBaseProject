using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUtil : MonoSingleton<SceneUtil>
{
    public SaveScene saveScene;//����Ĵ浵��

    protected override void Awake()
    {
        base.Awake();     
        DontDestroyOnLoad(this.gameObject);
    }
    //�������˵�
    public void MainMenu()
    {
        StartCoroutine(GoMainMenu());
    }
    //ָ��ת��
    public void TransScene(string sceneName, int targetId)
    {
        StartCoroutine(Transition(sceneName, targetId));  
    }
    //�ص��浵��
    public void TransScene()
    {
        StartCoroutine(Transition(saveScene.sceneName, saveScene.targetId));
    }

    private IEnumerator Transition(string sceneName, int targetId)
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 1f;//��ʼ��ʱ��߶�
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
        Debug.LogError("û���ҵ�Ŀ�ĵ�");
    }
    IEnumerator GoMainMenu()
    {
        yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1f;//��ʼ��ʱ��߶�
    }
}
