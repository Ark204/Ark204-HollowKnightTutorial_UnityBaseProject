using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*Allows the camera to shake when the player punches, gets hurt, etc. Put any other custom camera effects in this script!*/

public class CameraEffects : MonoSingleton<CameraEffects>//单例相机震动控制器
{
    public Vector3 cameraWorldSize;//不知道干嘛的
    public CinemachineFramingTransposer cinemachineFramingTransposer;
    [SerializeField] private CinemachineBasicMultiChannelPerlin multiChannelPerlin;
    public float screenYDefault;
    public float screenYTalking;
    [Range(0, 10)]
    [System.NonSerialized] public float shakeLength = 10;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    protected override void Awake()
    {
        base.Awake();
        //Init();
    }

    //void Start()
    //{
    //    //Ensures we can shake the camera using Cinemachine. Don't really worry too much about this weird stuff. It's just Cinemachine's variables.
    //    //cinemachineFramingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    //    //screenYDefault = cinemachineFramingTransposer.m_ScreenX;

    //    //Inform the player what CameraEffect it should be controlling, no matter what scene we are on.
    //    //Camera 全局获取
    //}

    void Update()
    {
        if (multiChannelPerlin == null) {return; }//震动控制器为空，返回
        //相机震动
        multiChannelPerlin.m_FrequencyGain += (0 - multiChannelPerlin.m_FrequencyGain) * Time.deltaTime * (10 - shakeLength);
    }

    public void Shake(float shake, float length)
    {
        Init();//重初始化
        shakeLength = length;
        multiChannelPerlin.m_FrequencyGain = shake;
    }
    public void Shake(float shake)
    {
        Shake(shake, 1f);
    }
    //每次使用震动时需要重初始化
    void Init()
    {
        virtualCamera =Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera;//获取当前活跃虚拟相机
        multiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();//更新引用
    }
}
