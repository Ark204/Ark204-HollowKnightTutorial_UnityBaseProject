using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������������ֻ���𳡾�����ʱ���ж���������
public class SceneCreator : MonoBehaviour
{
    [SerializeField] int index;//����
    [SerializeField] bool target = true;//Ŀ���б�
    [SerializeField] List<Object> OnFalse;//falseʱ��������
    [SerializeField] List<Object> OnTrue;//trueʱ��������
    private void Awake()
    {
        //if(DataManager.Instance.m_saveData.GetBool(index))
        //{
        //    foreach(var elem in OnFalse) 
        //        game=Instantiate(elem, transform) as GameObject;//�������壬����Ϊ������
        //}
        //else
        //{
        //    foreach (var elem in OnTrue)
        //        game = Instantiate(elem, transform) as GameObject;//�������壬����Ϊ������
        //}
    }
    private void Start()
    {
        if (DataManager.Instance.m_saveData.GetBool(index,target)==false)
        {
            GameObject game;
            foreach (var elem in OnFalse)
                game = Instantiate(elem, transform) as GameObject;//�������壬����Ϊ������
        }
        else
        {
            GameObject game;
            foreach (var elem in OnTrue)
                game = Instantiate(elem, transform) as GameObject;//�������壬����Ϊ������
        }
    }
}
