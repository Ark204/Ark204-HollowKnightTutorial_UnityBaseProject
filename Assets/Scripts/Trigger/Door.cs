using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������Ǵ���
public class Door : BTranslate
{
#if UNITY_EDITOR
    public Color color = Color.blue;//��ɫ
#endif
    private void OnDrawGizmos()
    {
        Gizmos.color = color;//������ɫ
        Gizmos.DrawWireSphere(transform.position, 2f);//���ƴ��͵�
    }
}
