using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;
    [SerializeField] ItemInfo info;//��Ʒ��Ӧ��Info
    [SerializeField] Bag bag;//��Ӧ�ı���
    [SerializeField] uint count = 1;//��Ʒ����
    public UnityEngine.Events.UnityEvent triggerEvent = new UnityEngine.Events.UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
        {
            isTouchPlayer = true;
            {
                bag.AddItem(info, count);//�򱳰������ָ����������Ʒ
                triggerEvent?.Invoke(); //�����¼�
                Destroy(transform.parent.gameObject);//���ٸ�����
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
}
