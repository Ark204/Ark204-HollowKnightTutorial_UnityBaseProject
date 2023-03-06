using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//向随机坐标移动
public class MoveToRandomTar : ActionNode
{
    [SerializeField] [Range(-1, 1)] int baseFace = 1;//初始朝向(默认朝右 为1)
    [SerializeField]Vector2 xRange=new Vector2(-10,10);//x轴范围
    float targetX;//本次移动的随机X坐标
    [SerializeField] float minDistance;//下一个随机巡逻点的最小距离
    public float speed = 5;//移动速度
    public float stoppingDistance = 0.1f;//停止距离
    protected override void OnStart()
    {
        float x = Random.Range(xRange.x, xRange.y - 2 * minDistance);
        if (x > context.transform.position.x - minDistance) x += 2 * minDistance;
        targetX = x;//获取随机坐标点
        //面向该坐标
        if (targetX - context.transform.position.x > 0) context.transform.localScale = new Vector3(-baseFace, context.transform.localScale.y, context.transform.localScale.z);
        else if (targetX - context.transform.position.x < 0) context.transform.localScale = new Vector3(baseFace, context.transform.localScale.y, context.transform.localScale.z);
    }
    protected override State OnUpdate()
    {
        //开始移动
        if (Mathf.Abs(targetX - context.transform.position.x) > stoppingDistance)//判断剩余距离
        {
            context.transform.position = Vector2.MoveTowards(context.transform.position,
                 new Vector2(targetX,context.transform.position.y), speed * Time.deltaTime);
            return State.Running;//停止移动
        }
        else return State.Success;//移动完成
    }

    protected override void OnStop() { }
    public override void OnDrawGizmos()
    {
        if (context == null||context.transform==null) return;  
        Gizmos.DrawWireCube(new Vector3((xRange.x+xRange.y)/2,context.transform.position.y,0), new Vector3(Mathf.Abs(xRange.x-xRange.y), 3, 0));
    }
}
