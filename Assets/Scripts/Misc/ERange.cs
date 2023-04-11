using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//怪物活动范围
public class ERange : MonoBehaviour
{
    [SerializeField]public Vector2 center;
    [SerializeField]public  Vector2 size;
    public Vector2 xRange { get => new Vector2(center.x - size.x/2, center.x + size.x/2); }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position indicating the attentionRange
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, size);
    }
}
