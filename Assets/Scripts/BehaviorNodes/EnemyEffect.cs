using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    [SerializeField] float enableTime=0.3f;
    private void Start()
    {
        Destroy(this.gameObject, enableTime);
    }
}
