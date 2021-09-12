using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustGrabbable : MonoBehaviour
{
    private GrabLeft leftHand;
    private GrabRight rightHand;
    private bool isKinematic;
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<GrabLeft>();
        rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<GrabRight>();
        isKinematic = GetComponent<Rigidbody>().isKinematic;
    }

    
    void Update()
    {
        bool nowIsKinematic = GetComponent<Rigidbody>().isKinematic;
        if (nowIsKinematic)
        {
            if (!leftHand.isGrabbing)
            {

                if (rightHand.isGrabbing)
                {
                    if (rightHand.m_grabbedObj.gameObject != gameObject)
                    {
                        GetComponent<Rigidbody>().isKinematic = isKinematic;
                        Physics.IgnoreCollision(rightHand.gameObject.GetComponent<Collider>(),gameObject.GetComponent<Collider>(),false);
                        Physics.IgnoreCollision(leftHand.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
                    }
                }
                else
                {
                    Physics.IgnoreCollision(rightHand.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
                    Physics.IgnoreCollision(leftHand.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
                    GetComponent<Rigidbody>().isKinematic = isKinematic;
                }
                
            }

            if (!rightHand.isGrabbing)
            {
                if (leftHand.isGrabbing)
                {
                    if (leftHand.m_grabbedObj.gameObject != gameObject)
                    {
                        GetComponent<Rigidbody>().isKinematic = isKinematic;
                    }
                }
                else
                {
                    GetComponent<Rigidbody>().isKinematic = isKinematic;
                }
            }
            
        }        
    }
}
