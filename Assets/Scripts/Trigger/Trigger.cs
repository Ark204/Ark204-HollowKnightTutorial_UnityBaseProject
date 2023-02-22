using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trigger : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;

    [SerializeField] CinemachineVirtualCameraBase Main;
    [SerializeField] CinemachineVirtualCameraBase Boss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
        {
            isTouchPlayer = true;
            //Core.Character.CameraController.Instance.SetBorders(collision);
            Main.VirtualCameraGameObject.SetActive(false);
            Boss.VirtualCameraGameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
}
