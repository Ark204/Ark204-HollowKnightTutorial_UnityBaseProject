using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using BerserkPixel.Prata;
//����������
public class TipsTrigger : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;//��ע�Ĵ�����
    [SerializeField] bool isTouchPlayer = false;//�Ƿ�Ӵ�����
    [SerializeField] string keyName = "upKey";//������
    [SerializeField] [TextArea]public string text;//��ʾ�ı�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//���ڹ�ע���ڣ�����
        isTouchPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//���ڹ�ע���ڣ�����
        isTouchPlayer = false;
    }
    private void Update()
    {
        if (isTouchPlayer && Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
        {
            BerserkPixel.Prata.DialogManager.Instance.ShowTips(text, 1.5f);
        }
    }
}
