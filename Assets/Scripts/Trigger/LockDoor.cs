using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɶ�̬���ص���
public class LockDoor : MonoBehaviour
{
    [SerializeField]bool m_isLock=false;//�ŵ�ǰ����״̬
    [SerializeField] float offset = 3f;
    [SerializeField] float time=1f;//����ʱ��
    float speed;//�ƶ��ٶ�
    float currentTime = 0f;//ʣ���ƶ�ʱ��
    public bool IsLock {
        get => m_isLock;
        set
        {
            if (value == m_isLock) return;//״̬���� ֱ�ӷ���
            m_isLock = value;//����״̬
            if (value == true) speed = offset / time; //�ɹص���
            else speed = -offset / time;//�ɿ�����
            currentTime = time;
        }
    }
    private void FixedUpdate()
    {
        if (currentTime <= 0) return;
        transform.Translate(0, Time.fixedDeltaTime*speed, 0);
        currentTime -= Time.fixedDeltaTime;//ʣ���ƶ�ʱ�����
    }
}
