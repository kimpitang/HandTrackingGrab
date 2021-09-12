using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class grabChecker : MonoBehaviour
{

    public GameObject lefthand;
    public GameObject righthand;
    public UnityEvent grabCheck;

    private GrabLeft grabLeft;
    private GrabRight grabRight;

    private bool grabOnce;
    private bool checkNext;

    private OVRGrabbable left_grabbable;
    private OVRGrabbable right_grabbable;
    // Start is called before the first frame update
    void Start()
    {
        grabLeft = lefthand.GetComponent<GrabLeft>();
        grabRight = righthand.GetComponent<GrabRight>();
        left_grabbable = null;
        right_grabbable = null;
        //StartCoroutine(GrabChecked());
    }

    // Update is called once per frame
    void Update()
    {
        if (grabLeft.isGrabbing || grabRight.isGrabbing)
        {
            grabOnce = true;
        }

        if(grabOnce && !checkNext && (!grabLeft.isGrabbing && !grabRight.isGrabbing))
        {
            checkNext = true;
            Invoke("GrabForceFinish", 5f);
            //Invoke("GrabChecked", 5f);

            //invoke가 update문에 있으면 계속 호출됨
            //GrabForceFinish 안의 GrabChecked가 실행되어 state++이 계속 호출, end Stage로 넘어감
            //checkNext로 제어
        }
    }

    public void GrabForceFinish()
    {
        //grabLeft.GrabFinish();
        //grabRight.GrabFinish();
        GestureRecongizedLeft gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        GestureRecongizedRight gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        if (grabLeft.insideObject)
        {
            gestureRecongizedLeft.CanGrabbingTurnOff();
            if (grabLeft.isGrabbing)
            {
                GameObject grabbableObject = grabLeft.grabbedObject.gameObject;
                GameObject grabDetector = grabbableObject.transform.GetChild(0).gameObject;
                left_grabbable = grabLeft.grabbedObject;
                grabDetector.SetActive(false);
            }
            
        }
        if (grabRight.insideObject)
        {
            gestureRecongizedRight.CanGrabbingTurnOff();
            if (grabRight.isGrabbing)
            {
                GameObject grabbableObject = grabRight.grabbedObject.gameObject;
                GameObject grabDetector = grabbableObject.transform.GetChild(0).gameObject;
                right_grabbable = grabRight.grabbedObject;
                grabDetector.SetActive(false);
            }
            
        }
        grabLeft.GrabFinish();
        grabRight.GrabFinish();
        grabRight.InsideObjectTurnOff();
        grabLeft.InsideObjectTurnOff();
        gestureRecongizedLeft.CanGrabbingTurnOn();
        gestureRecongizedRight.CanGrabbingTurnOn();
        GrabChecked();
        Debug.Log("ForceFinish");
    }

    /*
    public IEnumerator GrabChecked()
    {
        yield return new WaitUntil(() => (grabLeft.isGrabbing || grabRight.isGrabbing));
        yield return new WaitForSeconds(5);
        GrabForceFinish();
        grabCheck.Invoke();
    }
    */

    public void GrabChecked()
    {
        grabCheck.Invoke();

    }

    public void RemoveCanidates()
    {
        if (left_grabbable != null)
        {
            grabLeft.RemoveCandidates(left_grabbable);
            grabRight.RemoveCandidates(left_grabbable);
        }
        if(right_grabbable != null)
        {
            grabLeft.RemoveCandidates(right_grabbable);
            grabRight.RemoveCandidates(right_grabbable);
        }
    }

}
