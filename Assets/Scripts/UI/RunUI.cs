using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ���ݽ���ʱ������UI�Ĺ���
public class RunUI : MonoBehaviour
{
    public BlockUI gameMenu;//��Ϸ�ڲ˵�
    public BlockUI bag;//����
    public BlockUI skill;//���ܱ�
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) gameMenu.OpenUI();//����Ϸ�ڲ˵�
        if (Input.GetKeyDown(KeyCode.X)) bag.OpenUI();
        if (Input.GetKeyDown(KeyCode.C)) skill.OpenUI();
    }
}
