using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class TelePorting : EnemyAction
{
    [SerializeField] float distance=4;//瞬移目标点距离目标的距离
    [SerializeField] float radius=12;//场地半径
    [SerializeField] float offsetY;//瞬移后Y轴偏移
    [SerializeField] bool followY=false;//Y轴跟随
    [SerializeField] float landY;//不开启Y轴跟随时瞬移后的Y坐标
    protected override void OnStart() {
        base.OnStart();
        //计算左右两个瞬移目标点
        float left = range.target.position.x - distance;
        float right =range.target.position.x + distance;
        float axisY = followY ? range.target.position.y : landY;
        if (Mathf.Abs(left) > radius) context.transform.position = new Vector2(right, axisY+offsetY);//y轴跟随
        else if(Mathf.Abs(right)>radius) context.transform.position= new Vector2(left, axisY+offsetY);//y轴跟随
        else//随机选择
        {
            float random = Random.Range(0, 2) == 0 ? left : right;
            context.transform.position = new Vector2(random, axisY+offsetY);//y轴跟随
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
