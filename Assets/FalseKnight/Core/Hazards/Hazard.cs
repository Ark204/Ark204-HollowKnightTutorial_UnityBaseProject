using Core.Character;
using UnityEngine;
using System.Collections.Generic;

namespace Core.Hazards
{
    //接触造成伤害
    public class Hazard : MonoBehaviour
    {
        [SerializeField] LayerMask triggerLayer;//关注的触发层
        [SerializeField] int damage = 10;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if ((triggerLayer.value & 1 << collider.gameObject.layer) < 0) return;//不在关注层中 返回
            PlayerCtrl player = collider.GetComponent<PlayerCtrl>();//尝试获取玩家
            if (player != null) { player.Hurt(damage, Vector2.zero); return; }//造成伤害
            else
            {
                BeAttackedable attackedable = collider.GetComponent<BeAttackedable>();//尝试获取怪物
                if (attackedable != null) attackedable.OnAttackHit(Vector2.zero, Vector2.zero, damage);//造成伤害
            }
        }
        private void OnTriggerStay2D(Collider2D collider)
        {
            if ((triggerLayer.value & 1 << collider.gameObject.layer) < 0) return;//不在关注层中 返回
            PlayerCtrl player = collider.GetComponent<PlayerCtrl>();//尝试获取玩家
            if (player != null) { player.Hurt(damage, Vector2.zero); return; }//造成伤害
            else
            {
                BeAttackedable attackedable = collider.GetComponent<BeAttackedable>();//尝试获取怪物
                if (attackedable != null) attackedable.OnAttackHit(Vector2.zero, Vector2.zero, damage);//造成伤害
            }
        }
    }
}