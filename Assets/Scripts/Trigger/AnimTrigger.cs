using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�붯����صĴ�����(SetBool)
public class AnimTrigger : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer;//��ע�Ĵ�����
    [SerializeField] Animator animator;//��Ӧ�Ķ���������
    [SerializeField] string proName ="active";//������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//���ڹ�ע���� ����
        animator.SetBool(proName, !animator.GetBool(proName));//����boolֵ
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//���ڹ�ע���� ����
        animator.SetBool(proName, !animator.GetBool(proName));//����boolֵ
    }
}
