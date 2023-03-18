using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����Ի����
public class DestoryTri : MonoBehaviour
{
    [SerializeField] LayerMask triggerLayer ;//��ע�Ĵ�����
    [SerializeField] GameObject destoryObj;//�Ի�ʱ���ٵ�����
    public event System.Action onDestory;//�Ի��¼�
    private void Awake() { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer.value & 1 << collision.gameObject.layer) <= 0) return;//���ڹ�ע���� ����
        Debug.Log(collision.gameObject.name + "  :" + collision.gameObject.layer+"�����ƶ�");
        onDestory?.Invoke();
        GameObject destory = destoryObj == null ? gameObject : destoryObj;//��û��ָ���������壬����������
        Destroy(destory);//ֻ�������������������ɴ���
    }
}
