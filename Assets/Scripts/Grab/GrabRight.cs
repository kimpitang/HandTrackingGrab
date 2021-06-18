using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class GrabRight : OVRGrabber
{
    private bool isGrabbing;
    private bool insideObject;
    private Vector3 prevPost;
    private Quaternion prevRot;
    private OVRHand m_hand;
    private OVRMeshRenderer m_renderer;


    private GameObject r_preview;

    public Material defaultHandMaterial;
    public Material noneMaterial;
    //private float pinchThreshold = 0.6f;
    //private HandDetector handDetector;

    protected override void Start()
    {
        Debug.Log("start!");
        base.Start();
        m_hand = GetComponent<OVRHand>();
        r_preview = GameObject.Find("PreviewHand_R");
        r_preview.SetActive(false);
        r_preview.gameObject.GetComponent<GameplayHand>().enabled = false;
        //renderer
        m_renderer = m_hand.GetComponent<OVRMeshRenderer>();
        isGrabbing = false;
        insideObject = false;
    }


    public override void Update()
    {

        base.Update();

        //object 닿지 않을 때
        if (!(insideObject))
            return;


        if (isGrabbing)
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
        insideObject = false;
    }

    public void GrabStart()
    {
        if (!(insideObject))
        {
            print("아직!");
        }
        if (!(insideObject) && (isGrabbing))
        {
            //print("아직!");
            return;
        }


        Debug.Log("Grab Grabbing");
        isGrabbing = true;

        if (m_grabbedObj == null && m_grabCandidates.Count > 0 && isGrabbing)
        {
            Debug.Log("grabbing");
            GrabBegin();
        }
    }

    public void GrabFinish()
    {
        if (!(insideObject) && !(isGrabbing))
            return;
        Debug.Log("Grab Not Grabbing");
        isGrabbing = false;

        if (m_grabbedObj != null && !(isGrabbing))
        {
            SetPlayerIgnoreCollision(m_grabbedObj.gameObject, false);
            Debug.Log("not grabbing");
            GrabEnd2();
        }
    }


    protected override void GrabBegin()
    {
        base.GrabBegin();
        //renderer
        //m_renderer.enabled = false;
        m_renderer._originalMaterial = noneMaterial;

        r_preview.SetActive(true);
        r_preview.gameObject.GetComponent<GameplayHand>().enabled = true;



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

        GrabbableRelease(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        GrabVolumeEnable(true);

        //renderer
        //m_renderer.enabled = true;
        m_renderer._originalMaterial = defaultHandMaterial;
        r_preview.SetActive(false);
        r_preview.gameObject.GetComponent<GameplayHand>().enabled = false;

    }
}
