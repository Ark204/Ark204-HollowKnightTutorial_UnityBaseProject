using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : BTranslate
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;
    [SerializeField] KeyCode keycode = KeyCode.Alpha7;
    [SerializeField] SaveScene saveScene;
    [SerializeField] float offset=2f;

    public override void Translate(GameObject gameObject)
    {
        var pos = transform.position;
        pos.y += offset;
        gameObject.transform.position =pos ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
    private void Update()
    {
        if (isTouchPlayer && Input.GetKeyDown(keycode))
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;//��ȡ��ǰ��������
            saveScene.sceneName = sceneName;//���´浵��
            saveScene.targetId = Id;//����Ŀ���
            BSaveData.Save();//ͳһ�浵
        }
    }
}
