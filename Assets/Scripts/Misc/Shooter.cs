using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletBody;//发射物物理组件
    [SerializeField] Vector2 dir;//方向
    [SerializeField] float force;//力度
    [SerializeField] bool loop = true;
    [SerializeField] float intervalTime=1f;//间隔时间
    float lastTriTime;//上次发射时间
    public void Shoot()
    {
        //bulletBody.gameObject
        var newbullet=Instantiate(bulletBody.gameObject);
        newbullet.transform.position = bulletBody.position;//设置坐标
        newbullet.SetActive(true);//设为启用
        newbullet.GetComponent<Rigidbody2D>().AddForce(dir.normalized*force, ForceMode2D.Impulse);//发射，冲量形式
    }
    private void Update()
    {
        if (!loop) return;//非重复型，返回
        if (Time.fixedTime - lastTriTime > intervalTime)
        {
            lastTriTime = Time.fixedTime;//重置时间
            Shoot();//发射
        }
    }
}
