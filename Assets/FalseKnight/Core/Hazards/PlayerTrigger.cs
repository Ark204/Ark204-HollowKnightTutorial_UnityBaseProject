using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] float damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==10)
        {
            collision.GetComponent<BeAttackedable>().OnAttackHit(Vector2.zero, Vector2.zero, damage);
        }
    }
}
