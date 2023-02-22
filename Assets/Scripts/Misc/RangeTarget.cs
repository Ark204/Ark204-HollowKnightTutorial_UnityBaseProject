using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTarget : MonoBehaviour
{
    public event Action<Collider2D> onTargetEnter;
    public event Action<Collider2D> onTargetExit;
    //[SerializeField] LayerMask targetLayer;
    [SerializeField] int targetLayer=6;
    public Transform target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayer)
        {
            Debug.Log("Enter");
            onTargetEnter?.Invoke(collision);
            target = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayer)
        {
            Debug.Log("Exit");
            onTargetExit?.Invoke(collision);
            if (target == collision.transform) target = null;
        }
    }
}
