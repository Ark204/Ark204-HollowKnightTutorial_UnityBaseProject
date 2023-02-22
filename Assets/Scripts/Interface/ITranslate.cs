using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITranslate
{
    int Id { get; }
    void Translate(GameObject gameObject);
}
public abstract class BTranslate : MonoBehaviour ,ITranslate
{
    [SerializeField] int m_Id;//×ÔÉíID
    
    public int Id => m_Id;

    public virtual void Translate(GameObject gameObject)
    {
        gameObject.transform.position = transform.position;
    }
}