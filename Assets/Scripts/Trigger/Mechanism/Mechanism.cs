using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ǿ���ƶ�
public class Mechanism : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer ;//��ע�Ĵ�����
    [SerializeField]Vector2 position;//���͵�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) < 0) return;//���ڹ�ע���� ����
        collision.transform.position = position;//ǿ�ƴ���
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(position, 2f);//���ƴ��͵�
    }
}
