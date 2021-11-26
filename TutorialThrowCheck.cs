using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialThrowCheck : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;
    [SerializeField] private GameObject grabbableObject;
    [SerializeField] private GameObject leftHandObject;
    [SerializeField] private GameObject rightHandObject;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private bool throwCheck;
    private bool once;
    private OVRGrabbable left_grabbable;
    private OVRGrabbable right_grabbable;
    void Start()
    {
        leftHand = leftHandObject.GetComponent<GrabLeft>();
        rightHand = rightHandObject.GetComponent<GrabRight>();
        throwCheck = false;
        once = false;
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(0.5f);
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
        tutorialManager.EndStep4();
    }
    
    public void ThrowingTurnOn()
    {
        throwCheck = true;
    }

    void Update()
    {
        if (throwCheck) { 
            
            if (!once)
            {
                StartCoroutine(Loading());
                effectAudioManager.ThrowEffect();
                once = true;
            }
        }
    }
}
