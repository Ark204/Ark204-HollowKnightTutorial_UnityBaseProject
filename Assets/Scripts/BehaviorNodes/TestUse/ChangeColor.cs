using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class ChangeColor : EnemyAction
{
    [SerializeField] Color color;
    protected override void OnStart() {
        context.gameObject.GetComponentInChildren<SpriteRenderer>().color =this.color;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
