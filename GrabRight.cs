using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRight : OVRGrabber
{
    public bool isGrabbing;
    public bool insideObject;

    private bool canGrabbing;
    private Vector3 prevPost;
    private Quaternion prevRot;

    private ThrowGrabbable throwGrabbable;

    protected override void Start()
    {
        Debug.Log("start!");
        base.Start();
        canGrabbing = false;
        insideObject = false;
        isGrabbing = false;
    }


    public override void Update()
    {

        base.Update();

        //object 닿지 않을 때
        if (!(insideObject))
            return;


        if (canGrabbing)
        {

            prevPost = transform.position;
            prevRot = transform.rotation;

        }

    }

    public void InsideObjectTurnOn()
    {
        insideObject = true;
    }

    public void InsideObjectTurnOff()
    {
        
        m_grabbedObj = null;
        insideObject = false;
        canGrabbing = false;
        isGrabbing = false;
    }

    public void GrabStart()
    {
        
        if (!(insideObject) || (canGrabbing))
        {
            return;
        }


        //Debug.Log("Grab Grabbing");
        canGrabbing = true;
        //print("m_grabbedObj: "+m_grabbedObj);
        //print("m_grabCandidates.cout: "+m_grabCandidates.Count);
        List<OVRGrabbable> deleteCandidates = new List<OVRGrabbable>();
        foreach (KeyValuePair<OVRGrabbable, int> grabCandidate in m_grabCandidates)
        {
            //print("grabCandidate: "+grabCandidate.Key); // log기록
            if (grabCandidate.Key == null)
            {
                OVRGrabbable grabbable = grabCandidate.Key;
                deleteCandidates.Add(grabbable);
                //m_grabCandidates.Remove(grabbable);
            }
        }
        foreach (OVRGrabbable deleteCandidate in deleteCandidates)
        {
            m_grabCandidates.Remove(deleteCandidate);
        }
        //print("canGrabbing: "+canGrabbing);


        if (m_grabbedObj == null && m_grabCandidates.Count > 0 && canGrabbing)
        {
            Debug.Log("grabbing");
            GrabBegin();
            isGrabbing = true;
        }
    }

    public void GrabFinish()
    {
        if (!(insideObject) || !(canGrabbing))
            return;
        //Debug.Log("Grab Not Grabbing");
        canGrabbing = false;
        //print("m_grabbedObj: "+m_grabbedObj);
        //print("isGrabbing: " + isGrabbing);
        if (m_grabbedObj != null && !canGrabbing)
        {
            throwGrabbable = m_grabbedObj.gameObject.GetComponent<ThrowGrabbable>();
            SetPlayerIgnoreCollision(m_grabbedObj.gameObject, false);
            Debug.Log("not grabbing");
            isGrabbing = false;
            GrabEnd();
        }
    }


    protected override void GrabBegin()
    {
        base.GrabBegin();
    }

    
    protected override void GrabEnd()
    {
        
        if (m_grabbedObj != null)
        {
            OVRPose localPose = new OVRPose { position = OVRInput.GetLocalControllerPosition(m_controller), orientation = OVRInput.GetLocalControllerRotation(m_controller) };
            OVRPose offsetPose = new OVRPose { position = m_anchorOffsetPosition, orientation = m_anchorOffsetRotation };
            localPose = localPose * offsetPose;

            OVRPose trackingSpace = transform.ToOVRPose() * localPose.Inverse();
            Vector3 linearVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerVelocity(m_controller);
            Vector3 angularVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerAngularVelocity(m_controller);
            Vector3 handCenterOfMass = GetComponent<Rigidbody>().centerOfMass;
            Vector3 handVelocityCross = Vector3.Cross(angularVelocity, m_grabbedObjectPosOff - handCenterOfMass);
            if (throwGrabbable != null)
                throwGrabbable.SetHandVelocityCross(handVelocityCross);
            GrabbableRelease(linearVelocity, angularVelocity);
        }

        // Re-enable grab volumes to allow overlap events
        GrabVolumeEnable(true);
        
    }

    public void RemoveCandidates(OVRGrabbable grabbable)
    {
        print("removeCandidate");
        if (grabbable == null) return;
        print("removeCandidate2");
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
    }
    public void AddCandidates(OVRGrabbable grabbable)
    {
        if (grabbable == null) return;

        foreach (KeyValuePair<OVRGrabbable, int> grabCandidate in m_grabCandidates)
        {
            if (grabCandidate.Key == grabbable)
            {
                return;
            }
        }


        // Add the grabbable
        int refCount = 0;
        m_grabCandidates.TryGetValue(grabbable, out refCount);
        m_grabCandidates[grabbable] = refCount + 1;
    }
}
