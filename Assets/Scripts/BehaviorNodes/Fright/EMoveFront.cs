using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//移动接近玩家
public class EMoveFront : EnemyAction
{
    [SerializeField] [Range(-1, 1)] int baseFace = 1;//初始朝向(默认朝右 为1)
    public float speed = 3f;//移动速度
    public float stoppingDistance = 2.5f;//停止距离
    protected override State OnUpdate() {
        //开始移动
        if (range.target == null) return State.Failure;//丢失目标
        if (Vector2.Distance(range.target.position, context.transform.position) > stoppingDistance)//判断剩余距离
        {
            context.transform.position = Vector2.MoveTowards(context.transform.position,
                 new Vector2(range.target.position.x, context.transform.position.y), speed * Time.deltaTime);
            return State.Running;//停止移动
        }
        else return State.Success;//移动完成);
    }
}
