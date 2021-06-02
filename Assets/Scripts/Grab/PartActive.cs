using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartActive : MonoBehaviour
{
    private GameObject leftArm;

    void Start()
    {
        leftArm = gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        leftArm.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    public void Restore()
    {
        leftArm.gameObject.SetActive(true);
    }
}
