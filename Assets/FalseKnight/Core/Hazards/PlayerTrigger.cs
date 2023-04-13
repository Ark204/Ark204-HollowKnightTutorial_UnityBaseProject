using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] float damage = 1;
    [SerializeField] int id = 7;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==10)
        {
            var attackAble = collision.GetComponent<BeAttackedable>();
            if (attackAble == null) return;
            //ÕýÊ½ÃüÖÐ
            attackAble.OnAttackHit(Vector2.zero, Vector2.zero, damage);
            TQueueExtion.OnSkillHurt?.Invoke(id);
        }
    }
}
