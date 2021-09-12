using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{

    private GameObject leftHand;
    private GameObject rightHand;

    void Start()
    {
        leftHand = GameObject.FindWithTag("LeftHand");
        rightHand = GameObject.FindWithTag("RightHand");
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("lefDetector");
            leftHand.GetComponent<GrabLeft>().InsideObjectTurnOn();
        }

        if(otherCollider.gameObject.tag == "RightHand")
        {
            print("rightDetector");
            rightHand.GetComponent<GrabRight>().InsideObjectTurnOn();
        }
    }
    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("lefDetector");
            leftHand.GetComponent<GrabLeft>().InsideObjectTurnOff();
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            print("rightDetector");
            rightHand.GetComponent<GrabRight>().InsideObjectTurnOff();
        }
    }
}
