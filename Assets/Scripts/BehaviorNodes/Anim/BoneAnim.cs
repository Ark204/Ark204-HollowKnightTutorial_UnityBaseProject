using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

//���ڲ��Ź�������
public class BoneAnim : ActionNode
{
    [SerializeField] string animString;//�벥�ŵĶ�����
    protected override void OnStart() { }

    protected override State OnUpdate()
    {
        context.armatureComponent.animation.Play(animString);//���Ź�������
        return State.Success;
    }

    protected override void OnStop() { }
}
