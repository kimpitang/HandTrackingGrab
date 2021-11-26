using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumor : MonoBehaviour
{
    private GameObject detector;
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private GestureRecongizedLeft gestureRecongizedLeft;
    private GestureRecongizedRight gestureRecongizedRight;
    private bool updateActive;
    private bool grabOnceSuccess;
    [SerializeField] private ColonManager colonManager;
    [SerializeField] private GameObject effect; // 지금은 tempoaray effect로 함
    [SerializeField] private GameObject guideEffect;
    [SerializeField] private EffectAudioManager effectAudioManager;
    private OVRGrabbable tumorGrabbable;
    void Start()
    {
        detector = transform.GetChild(1).gameObject;
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        gestureRecongizedLeft = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedLeft>();
        gestureRecongizedRight = GameObject.FindGameObjectWithTag("GR").GetComponent<GestureRecongizedRight>();
        updateActive = true;
        grabOnceSuccess = false;
        tumorGrabbable = GetComponent<OVRGrabbable>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Vector3 position = transform.position;
            position.y = 10.2f;
            effectAudioManager.FalledTumorEffect();
            GameObject _effect = Instantiate(effect,transform.position,transform.rotation);
            Destroy(_effect,0.5f);
            colonManager.EndStage1(gameObject);
            updateActive = false;
        }    
    }

    public void AddCanidateProcess()
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

    

    void Update()
    {
        
        if (updateActive)
        {
            if(!leftHand.isGrabbing && !rightHand.isGrabbing)
            {
                if(grabOnceSuccess)
                {
                    print("grabOnceSuccess");
                    GetComponent<Rigidbody>().isKinematic = false;
                    GetComponent<Rigidbody>().useGravity = true;
                }
            }
            else
            {
                if(leftHand.m_grabbedObj != null)
                {
                    if(leftHand.m_grabbedObj.gameObject ==gameObject)
                        grabOnceSuccess = true;
                }
                if(rightHand.m_grabbedObj != null)
                {
                    if (rightHand.m_grabbedObj.gameObject == gameObject)
                        grabOnceSuccess = true;
                }
                
            }

            AddCanidateProcess();

        }



        if (leftHand.isGrabbing)
        {
            OVRGrabbable grabbable = leftHand.grabbedObject;
            if(tumorGrabbable == grabbable && guideEffect.activeSelf == true)
            {
                guideEffect.SetActive(false);
            }
        }
        if(rightHand.isGrabbing)
        {
            OVRGrabbable grabbable = rightHand.grabbedObject;
            if (tumorGrabbable == grabbable && guideEffect.activeSelf == true)
            {
                guideEffect.SetActive(false);
            }
        }
    }
}
