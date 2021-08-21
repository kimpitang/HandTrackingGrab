using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Grab : OVRGrabber
{
    private bool isGrabbing = false;
    private bool insideObject = false;
    private Vector3 prevPost;
    private Quaternion prevRot;
    private OVRHand m_hand;
    private float pinchThreshold = 0.6f;
    private HandDetector handDetector;
    
    protected override void Start()
    {
        Debug.Log("start!");
        base.Start();
        m_hand = GetComponent<OVRHand>();
    }

    
    public override void Update()
    {
        
        base.Update();

        //object 닿지 않을 때
        if (!(insideObject))
            return;

        GrabCheck();

        if (!isGrabbing)
        {
            Rigidbody rigidbody = handDetector.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
        }

        if (isGrabbing)
        {

            prevPost = transform.position;
            prevRot = transform.rotation;

        }

    }

    public void GrabCheck()
    {
        float pinchStrength = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        Debug.Log(pinchStrength);


        if (pinchStrength >= pinchThreshold)
        {
            Debug.Log("Grab Grabbing");
            isGrabbing = true;
            //handDetector.Grabbing();
            if (m_grabbedObj == null && m_grabCandidates.Count > 0 && isGrabbing)
            {
                Debug.Log("grabbing");
                GrabBegin();
            }

        }
        else
        {
            Debug.Log("Grab Not Grabbing");
            isGrabbing = false;
            handDetector.UnGrabbing();
            if (m_grabbedObj != null && !(isGrabbing))
            {
                Debug.Log("not grabbing");
                GrabEnd2();
            }

        }
    }

    protected override void GrabBegin()
    {
        base.GrabBegin();
    }

    

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag != "GrabCollider")
        {
            return;
        }

        if (otherCollider.gameObject.tag == "GrabCollider")
        {
            // Get the grab trigger
            OVRGrabbable grabbable = otherCollider.GetComponent<OVRGrabbable>() ?? otherCollider.GetComponentInParent<OVRGrabbable>();
            if (grabbable == null) return;

            // Add the grabbable
            int refCount = 0;
            m_grabCandidates.TryGetValue(grabbable, out refCount);
            m_grabCandidates[grabbable] = refCount + 1;

            handDetector = otherCollider.gameObject.transform.parent.gameObject.GetComponent<HandDetector>();
            insideObject = true;
        }
        
    }

    void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag != "GrabCollider")
        {
            return;
        }

        if (otherCollider.gameObject.tag == "GrabCollider")
        {
            OVRGrabbable grabbable = otherCollider.GetComponent<OVRGrabbable>() ?? otherCollider.GetComponentInParent<OVRGrabbable>();
            if (grabbable == null) return;

            // Remove the grabbable
            int refCount = 0;
            bool found = m_grabCandidates.TryGetValue(grabbable, out refCount);
            if (!found)
            {
                return;
            }

            if (refCount > 1)
            {
                m_grabCandidates[grabbable] = refCount - 1;
            }
            else
            {
                m_grabCandidates.Remove(grabbable);
            }

            if (m_grabbedObj != null && !(isGrabbing))
            {
                GrabEnd2();
            }
            insideObject = false;
            isGrabbing = false;
            handDetector = null;
        }
    }


    public void GrabEnd2()
    {
       
        if (m_grabbedObj == null)
        {
            GrabVolumeEnable(true);
            return;
        }
        /*
        Vector3 linearVelocity = (transform.parent.position - prevPost)/Time.deltaTime; //속도 = (변위)/시간
        Vector3 angularVelocity = (transform.parent.eulerAngles - prevRot.eulerAngles)/Time.deltaTime;
        */
        
        Vector3 linearVelocity = (transform.position - prevPost); //속도 = (변위)/시간
        Vector3 angularVelocity = (transform.rotation.eulerAngles - prevRot.eulerAngles);
        
        GrabbableRelease(new Vector3(0,0,0), new Vector3(0,0,0));
        GrabVolumeEnable(true);
    }

}
