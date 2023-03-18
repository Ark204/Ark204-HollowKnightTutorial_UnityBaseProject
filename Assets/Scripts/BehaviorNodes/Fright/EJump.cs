using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using DG.Tweening;

public class EJump : ActionNode
{
    [SerializeField] [Range(-1,1)] int baseFace=-1;
    [SerializeField] float horizontalForce = 5f;
    [SerializeField] float jumpForce = 10f;

    [SerializeField] float jumpTime;
    [SerializeField] bool shakeCameraOnLanding;

    Rigidbody2D body;
    bool hasLanded;
    Tween jumpTween;

    protected override void OnStart() {
        body = context.gameObject.GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(horizontalForce * context.transform.localScale.x * baseFace, jumpForce), ForceMode2D.Impulse);//³åÁ¿

        jumpTween=DG.Tweening.DOVirtual.DelayedCall(jumpTime, () =>
         {
             hasLanded = true;
             if (shakeCameraOnLanding) CameraEffects.Instance.Shake(100f, 1f);
             //Core.Character.CameraController.Instance.ShakeCamera(0.5f);

         },false);
    }
    protected override State OnUpdate() {
        return hasLanded? State.Success:State.Running;
    }
    protected override void OnStop()
    {
        hasLanded = false;
        jumpTween?.Kill();
    }
}
