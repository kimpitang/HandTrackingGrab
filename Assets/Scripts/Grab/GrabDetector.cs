using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("lefDetector");
            GameObject leftHand = GameObject.FindWithTag("LeftHand");
            leftHand.GetComponent<Grab>().InsideObjectTurnOn();
        }

        if(otherCollider.gameObject.tag == "RightHand")
        {
            print("rightDetector");
            GameObject rightHand = GameObject.FindWithTag("RightHand");
            rightHand.GetComponent<Grab>().InsideObjectTurnOff();
        }
    }
}
