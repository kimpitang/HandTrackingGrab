using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bronchial : MonoBehaviour
{
    
    private GameObject detector;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    private bool updateActive;

    void Start()
    {
        detector = transform.GetChild(0).gameObject;
        detector.SetActive(false);
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        updateActive = false;
    }

    public void Grabable()
    {
        updateActive = true;
        detector.SetActive(true);
        Vector3 position = transform.localPosition;
        position -= new Vector3(0.0f, 0.2f, 0.0f);
        transform.localPosition = position;
   
    }

    public void SetDestroy(string handName)
    {
        updateActive = false;
        if (handName.Equals("LeftHand"))
        {
            gestureRecongizedLeft.CanGrabbingTurnOff(); //grab 동작 인식X
            leftHand.InsideObjectTurnOff(); //grab을 끔
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
            detector.SetActive(false); //grabDetector를 끔
            leftHand.RemoveCandidates(grabbable);
            gestureRecongizedLeft.CanGrabbingTurnOn(); //grab 동작 인식이 되도록 함. -> grabDetector가 끈 상태라면, grab이 되지 않는다.
        }
        if (handName.Equals("RightHand"))
        {
            gestureRecongizedRight.CanGrabbingTurnOff(); //grab 동작 인식X
            rightHand.InsideObjectTurnOff(); //grab을 끔
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();
            detector.SetActive(false); //grabDetector를 끔
            rightHand.RemoveCandidates(grabbable);
            gestureRecongizedRight.CanGrabbingTurnOn(); //grab 동작 인식이 되도록 함. -> grabDetector가 끈 상태라면, grab이 되지 않는다.
        }
        leftHand.insideObject = false;
        rightHand.insideObject = false;
        Destroy(gameObject);
    }
    void Update()
    {
        if (!updateActive)
            return;
        if (detector.activeSelf == true)
        {
            OVRGrabbable grabbable = GetComponent<OVRGrabbable>() ?? GetComponentInParent<OVRGrabbable>();

            GrabDetector grabDetector = detector.GetComponent<GrabDetector>();
            if (leftHand.insideObject && grabDetector.GetInLeft())
            {
                if (gestureRecongizedLeft.GetCanGrabbing() && (gestureRecongizedLeft.GetGestureLeftName().Equals("Left_rock_v1") || gestureRecongizedLeft.GetGestureLeftName().Equals("Left_rock_v2")))
                {
                    leftHand.AddCandidates(grabbable);
                }
            }


            if (rightHand.insideObject && grabDetector.GetInRight())
            {
                if (gestureRecongizedRight.GetCanGrabbing() && (gestureRecongizedRight.GetGestureRightName().Equals("Right_rock_v1") || gestureRecongizedRight.GetGestureRightName().Equals("Right_rock_v2")))
                {
                    rightHand.AddCandidates(grabbable);
                }
            }
        }
    }
}
