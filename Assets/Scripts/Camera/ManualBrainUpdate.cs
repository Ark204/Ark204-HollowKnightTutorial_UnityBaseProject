using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ManualBrainUpdate : MonoBehaviour
{
    public CinemachineBrain brain;
    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        brain.ManualUpdate();
    }
}
