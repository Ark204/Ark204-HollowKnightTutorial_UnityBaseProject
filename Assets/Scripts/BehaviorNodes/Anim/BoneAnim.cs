using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//���ڲ��Ź�������
public class BoneAnim : ActionNode
{
    [SerializeField] string animString;//�벥�ŵĶ�����
    [SerializeField] int times=-1;//���Ŵ���
    [SerializeField] [Range(0,100)]float speed=1f;//���ű���
    protected override void OnStart() { }

    protected override State OnUpdate()
    {
        context.armatureComponent.animation.Play(animString,times);//���Ź�������
        //Debug.Log(context.armatureComponent.animation.animationConfig.animation.Length + "  :" + context.armatureComponent.animation.animationConfig.name);
        context.armatureComponent.animation.timeScale = speed;//���ö����ٶ�
        
        return State.Success;
    }

    protected override void OnStop() { }
}
