using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            GameObject leftHand = GameObject.FindWithTag("LeftHand");
            leftHand.GetComponent<Grab>().InsideObjectTurnOn();
        }

        if(otherCollider.gameObject.tag == "RightHand")
        {
            GameObject rightHand = GameObject.FindWithTag("RightHand");
            rightHand.GetComponent<Grab>().InsideObjectTurnOff();
        }
    }
}
