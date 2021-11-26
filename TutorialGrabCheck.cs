using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGrabCheck : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;
    [SerializeField] private GameObject grabbableObject;
    [SerializeField] private GameObject leftHandObject;
    [SerializeField] private GameObject rightHandObject;
    private GrabLeft leftHand;
    private GrabRight rightHand;

    private bool grabCheck;
    private bool nextPage;
    private OVRGrabbable left_grabbable;
    private OVRGrabbable right_grabbable;
    void Start()
    {
        leftHand = leftHandObject.GetComponent<GrabLeft>();
        rightHand = rightHandObject.GetComponent<GrabRight>();
        grabCheck = false;
        nextPage = false;
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.0f);
        GestureRecongizedLeft gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        GestureRecongizedRight gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        if (leftHand.insideObject)
        {
            gestureRecongizedLeft.CanGrabbingTurnOff();
            if (leftHand.isGrabbing)
            {
                GameObject grabbableObject = leftHand.grabbedObject.gameObject;
                GameObject grabDetector = grabbableObject.transform.GetChild(0).gameObject;
                left_grabbable = leftHand.grabbedObject;
                grabDetector.SetActive(false);
            }

        }
        if (rightHand.insideObject)
        {
            gestureRecongizedRight.CanGrabbingTurnOff();
            if (rightHand.isGrabbing)
            {
                GameObject grabbableObject = rightHand.grabbedObject.gameObject;
                GameObject grabDetector = grabbableObject.transform.GetChild(0).gameObject;
                right_grabbable = rightHand.grabbedObject;
                grabDetector.SetActive(false);
            }

        }
        leftHand.GrabFinish();
        rightHand.GrabFinish();
        leftHand.InsideObjectTurnOff();
        rightHand.InsideObjectTurnOff();
        gestureRecongizedLeft.CanGrabbingTurnOn();
        gestureRecongizedRight.CanGrabbingTurnOn();

        grabbableObject.SetActive(false);
        if (left_grabbable != null)
        {
            leftHand.RemoveCandidates(left_grabbable);
            rightHand.RemoveCandidates(left_grabbable);
        }
        if (right_grabbable != null)
        {
            leftHand.RemoveCandidates(right_grabbable);
            rightHand.RemoveCandidates(right_grabbable);
        }
        tutorialManager.EndStep3();
    }


    void Update()
    {
        if (!grabCheck)
        {
            if(leftHand.isGrabbing || rightHand.isGrabbing)
            {
                grabCheck = true;
            }
        }
        else
        {
            if(!nextPage)
            {
                if(!leftHand.isGrabbing && !rightHand.isGrabbing)
                {
                    nextPage = true;
                    StartCoroutine(Loading());
                }
            }
        }
    }


}
