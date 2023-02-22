using ArkSkill.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhaoHuan :BDele
{
    [SerializeField] Vector3 offset;
    [SerializeField] float scale = 1;
    [SerializeField] Object obj;
    private GameObject prefab;
    private float startTime;//TODO:从Info中移到Instance中
    public override void OnStart(SkillManager skillManager, SkillInfo skillInfo)
    {
        Vector3 center = new Vector3(skillManager.transform.localScale.x * offset.x + skillManager.transform.position.x, offset.y + skillManager.transform.position.y); ;
        prefab = (GameObject)Instantiate(obj, center, Quaternion.identity, skillManager.transform);//加载预制体//设为子物体
        prefab.transform.localScale *= scale;
        startTime = Time.realtimeSinceStartup;
    }
    public override void Invoke(SkillManager skillManager, SkillInfo skillInfo)
    {
        Destroy(prefab);
        skillManager.GetComponent<PlayerCtrl>().DestoryChild(obj,Time.realtimeSinceStartup-startTime);
    }
}
