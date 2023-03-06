using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TelePorting : EnemyAction
{
    [SerializeField] float distance=4;//˲��Ŀ������Ŀ��ľ���
    [SerializeField] float radius=12;//���ذ뾶
    [SerializeField] float offsetY;//˲�ƺ�Y��ƫ��
    [SerializeField] bool followY=false;//Y�����
    [SerializeField] float landY;//������Y�����ʱ˲�ƺ��Y����
    protected override void OnStart() {
        base.OnStart();
        //������������˲��Ŀ���
        float left = range.target.position.x - distance;
        float right =range.target.position.x + distance;
        float axisY = followY ? range.target.position.y : landY;
        if (Mathf.Abs(left) > radius) context.transform.position = new Vector2(right, axisY+offsetY);//y�����
        else if(Mathf.Abs(right)>radius) context.transform.position= new Vector2(left, axisY+offsetY);//y�����
        else//���ѡ��
        {
            float random = Random.Range(0, 2) == 0 ? left : right;
            context.transform.position = new Vector2(random, axisY+offsetY);//y�����
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
