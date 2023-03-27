using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����糡����������
public class SendTo : MonoBehaviour
{
    [SerializeField] string sceneName;//Ŀ�곡����
    [SerializeField] int m_TargetId;//Ŀ��ID
    [SerializeField] LayerMask triggerLayer;//��ע�Ĵ�����
    [SerializeField] string keyName=null;//������Ĭ��Ϊ��->�봥��
    //�봥��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0|| 
            InputManager.Instance.inputSystemDic.ContainsKey(keyName)) return;//���ڹ�ע����||������ ->����
        SceneUtil.Instance.TransScene(sceneName, m_TargetId);//ת�Ƶ���Ӧ�����Ķ�ӦID
    }
    //������
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!InputManager.Instance.inputSystemDic.ContainsKey(keyName)) return;//��Ϊ��->�봥��->ֱ�ӷ���
        //�ڹ�ע����&&���½�����
        if ((triggerLayer.value & 1 << collision.gameObject.layer) > 0 &&
            Input.GetKeyDown(InputManager.Instance.inputSystemDic[keyName]))
        {
            SceneUtil.Instance.TransScene(sceneName, m_TargetId);//ת�Ƶ���Ӧ�����Ķ�ӦID
        }
    }
}
