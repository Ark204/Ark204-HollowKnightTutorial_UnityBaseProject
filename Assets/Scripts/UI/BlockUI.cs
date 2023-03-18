using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ͣUI
public class BlockUI : MonoBehaviour
{
    private static BlockUI currBlockUI=null;//��ǰ��������UI

    private void OnEnable()
    {
        Time.timeScale = 0;//��ͣ��Ϸ
        currBlockUI = this;//TODO:���Կ��Ǻϲ��� UIBlocking{set}��
    }
    private void OnDisable()
    {
        Time.timeScale = 1;//�ָ���Ϸ
        currBlockUI = null;
    }
    //�ṩ�ⲿ���ó��Դ�
    public void OpenUI()
    {
        if (currBlockUI&&currBlockUI!=this) return;//���б��UI�򿪣�����
        //BlockUI==this||currBlockUI=null
        gameObject.SetActive(!gameObject.activeSelf);//��/�رձ�UI
 
    }
}
