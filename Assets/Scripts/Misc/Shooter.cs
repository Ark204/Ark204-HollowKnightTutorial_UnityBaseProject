using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletBody;//�������������
    [SerializeField] Vector2 dir;//����
    [SerializeField] float force;//����
    [SerializeField] bool loop = true;
    [SerializeField] float intervalTime=1f;//���ʱ��
    float lastTriTime;//�ϴη���ʱ��
    public void Shoot()
    {
        //bulletBody.gameObject
        var newbullet=Instantiate(bulletBody.gameObject);
        newbullet.transform.position = bulletBody.position;//��������
        newbullet.SetActive(true);//��Ϊ����
        newbullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized*force, ForceMode2D.Impulse);//���䣬������ʽ
    }
    private void Update()
    {
        if (!loop) return;//���ظ��ͣ�����
        if (Time.fixedTime - lastTriTime > intervalTime)
        {
            lastTriTime = Time.fixedTime;//����ʱ��
            Shoot();//����
        }
    }
}
