using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//�ؿ�������
public class LevelTrigger : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] bool isTouchPlayer = false;
    //��ͷ����
    //[SerializeField] CinemachineVirtualCameraBase Main;
    //[SerializeField] CinemachineVirtualCameraBase Boss;
    ////�������
    //[SerializeField] GameObject[] doors;
    ////�������ɿ���
    [SerializeField] int index;//��������
    //�����¼�
    public UnityEngine.Events.UnityEvent triggerEvent = new UnityEngine.Events.UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
        {
            isTouchPlayer = true;
            //Core.Character.CameraController.Instance.SetBorders(collision);
            //Main.VirtualCameraGameObject.SetActive(false);
            //Boss.VirtualCameraGameObject.SetActive(true);
            //if (DataManager.Instance.GetBool(index))//����δͨ��
            {
                triggerEvent?.Invoke();//���ô����¼�
                Destroy(this);//���ٱ����
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == playerLayer.value)
            isTouchPlayer = false;
    }
}
