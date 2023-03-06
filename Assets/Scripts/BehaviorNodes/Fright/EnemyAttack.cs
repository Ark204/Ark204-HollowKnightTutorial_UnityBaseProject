using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class EnemyAttack : EnemyAction
{
    [SerializeField] [Range(-1, 1)] int baseFace;
    [SerializeField] Bounds attackRange;
    [SerializeField] int damage=10;
    [SerializeField] float pushPower;
    [SerializeField] Object attackEffect;

    LayerMask layerMask;
    private void Awake()
    {
        layerMask = LayerMask.GetMask("Player");//Player
    }
    
    protected override State OnUpdate() {
        Vector3 center = new Vector3(context.transform.localScale.x * attackRange.center.x * baseFace + context.transform.position.x, attackRange.center.y + context.transform.position.y);
        var effect = (GameObject)Instantiate(attackEffect, center, Quaternion.identity, context.transform);//加载预制体//设为子物体
        var attackTarget = Physics2D.OverlapBox(center, attackRange.size, 0, layerMask);
        PlayerCtrl playerCtrl;
        if (attackTarget && attackTarget.TryGetComponent(out playerCtrl))
        {
            Vector3 force = playerCtrl.transform.position - context.transform.position;
            force = force.normalized * pushPower;
            playerCtrl.Hurt(damage, force);
        }
        return State.Success;
    }
    public override void OnDrawGizmos()
    {
        if (context==null||!context.transform)
        {
            Gizmos.DrawWireCube(Vector3.zero, attackRange.size);//绘制攻击范围
            return;
        }
        Vector3 center = new Vector3(context.transform.localScale.x * attackRange.center.x * baseFace + context.transform.position.x, attackRange.center.y + context.transform.position.y);
        Gizmos.DrawWireCube(center, attackRange.size);//绘制攻击范围
    }
}
