using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������
public class EnemyCreater : Creater
{
    [SerializeField]Object enemyPreb;
    GameObject enemy;
    private void Start()
    {
        if(Value)//��������
        {
            enemy = Instantiate(enemyPreb, transform) as GameObject;
            enemy.GetComponentInChildren<Core.Combat.Destructable>().OnDestroyed += SetValue;
        }
    }
    void SetValue()
    {
        Value = false;
    }
    private void OnDestroy()
    {
        if(enemy!=null)
        enemy.GetComponentInChildren<Core.Combat.Destructable>().OnDestroyed -= SetValue;
    }
}
