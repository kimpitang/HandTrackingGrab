using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetector : MonoBehaviour
{

    private GameObject leftHand;
    private GameObject rightHand;
    private bool inLeft;
    private bool inRight;

    void Start()
    {
        leftHand = GameObject.FindWithTag("LeftHand");
        rightHand = GameObject.FindWithTag("RightHand");
        inLeft = false;
        inRight = false;
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("leftDetector");
            inLeft = true;
            leftHand.GetComponent<GrabLeft>().InsideObjectTurnOn();
        }

        if(otherCollider.gameObject.tag == "RightHand")
        {
            print("rightDetector");
            inRight = true;
            rightHand.GetComponent<GrabRight>().InsideObjectTurnOn();
        }
    }
    public bool GetInLeft()
    {
        return inLeft;
    }
    public bool GetInRight()
    {
        return inRight;
    }
    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "LeftHand")
        {
            print("leftDetector");
            inLeft = false;
            leftHand.GetComponent<GrabLeft>().InsideObjectTurnOff();
            
            
        }

        if (otherCollider.gameObject.tag == "RightHand")
        {
            print("rightDetector");
            inRight = false;
            rightHand.GetComponent<GrabRight>().InsideObjectTurnOff();
           
        }
    }
}
