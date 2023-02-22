using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creater : MonoBehaviour
{
    [SerializeField] int index;//Êý¾ÝË÷Òý
    protected bool Value { get => DataManager.Instance.GetBool(index);
        set=> DataManager.Instance.SetBool(index,value); }
}
