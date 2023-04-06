using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ͼ�ڵ�
public class ScenePoint : MonoBehaviour
{
    [SerializeField] string sceneName;//��������
    [SerializeField] Color highLightColor=Color.red;//������ɫ
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        if(sceneName==UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            image.color = highLightColor;//���ø���
        }
    }
}
