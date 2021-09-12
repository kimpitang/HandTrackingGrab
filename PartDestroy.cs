using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDestroy : MonoBehaviour
{
    private GameObject grabDetector;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;

    void Start()
    {
        grabDetector = transform.GetChild(1).gameObject;
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
    }

    public void SetDestroy(string handName)
    {

        if (handName.Equals("LeftHand"))
        {
            gestureRecongizedLeft.CanGrabbingTurnOff(); //grab 동작 인식
            leftHand.InsideObjectTurnOff(); //grab을 끔
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
            leftHand.RemoveCandidates(grabbable);
            grabDetector.SetActive(false); //grabDetector를 끔
            gestureRecongizedLeft.CanGrabbingTurnOn(); //grab 동작 인식이 되도록 함. -> grabDetector가 끈 상태라면, grab이 되지 않는다.
        }
        if (handName.Equals("RightHand"))
        {
            gestureRecongizedRight.CanGrabbingTurnOff(); //grab 동작 인식X
            rightHand.InsideObjectTurnOff(); //grab을 끔
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
            rightHand.RemoveCandidates(grabbable);
            grabDetector.SetActive(false); //grabDetector를 끔
            gestureRecongizedRight.CanGrabbingTurnOn(); //grab 동작 인식이 되도록 함. -> grabDetector가 끈 상태라면, grab이 되지 않는다.
        }
        Destroy(gameObject);
    }
}
