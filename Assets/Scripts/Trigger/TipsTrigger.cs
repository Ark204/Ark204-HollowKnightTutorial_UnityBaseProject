using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using BerserkPixel.Prata;
//����������
public class TipsTrigger : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;//��ע�Ĵ�����
    [SerializeField] [TextArea]public string text;//��ʾ�ı�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//���ڹ�ע���ڣ�����
        DialogManager.Instance.ShowTips(text);//������ʾ
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//���ڹ�ע���ڣ�����
        DialogManager.Instance.HideTips();//�ر���ʾ
    }
}
