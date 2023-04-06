using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkSkill.Core;

//�����ƶ����
public class SetMove : BDele
{
    [SerializeField] float setGravity=0f;//�����õ������߶�
    float saveGravity;//����������߶�
    [SerializeField] bool useSpeed=false;//�Ƿ������ٶ�
    [SerializeField] float setSpeed;//�����õ�ˮƽ�ƶ��ٶ�
    float saveSpeed;//�����ˮƽ�ƶ��ٶ�
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.transform.Translate(new Vector3(0, 0.02f, 0)) ;
        saveGravity =rigidbody2D.gravityScale;//�����ʼ�����߶�
        rigidbody2D.gravityScale = setGravity;//���������߶�
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;//��ֹY���ƶ�
        //speed
        if (!useSpeed) return;
        var moveCtrl = skillManager.GetComponent<Core.Character.PlayerController>();
        saveSpeed=moveCtrl.speed;//����ԭ�����ٶ�
        moveCtrl.speed = setSpeed;//�������ٶ�
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        Rigidbody2D rigidbody2D = skillManager.GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = saveGravity;//��ԭ��ʼ�����߶�
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;//��ԭY���ƶ�
        //speed
        if (!useSpeed) return;
        var moveCtrl = skillManager.GetComponent<Core.Character.PlayerController>();
        moveCtrl.speed=saveSpeed;//�ָ�ԭ�����ٶ�
    }
}
