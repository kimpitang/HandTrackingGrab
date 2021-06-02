using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetector : MonoBehaviour
{

    private bool usingGravity = false;
    private Vector3 firstPos;
    private Quaternion firstRot;

    void Start()
    {

        firstPos = gameObject.transform.position;
        firstRot = gameObject.transform.rotation;

        //Do you use Gravity in rigidbody
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        if (rigidbody.useGravity)
            usingGravity = true;
        else
            usingGravity = false;
        
    }


    
    void Update()
    {
        if (transform.position.x > firstPos.x +4.0f || transform.position.x < firstPos.x -4.0f || transform.position.y > 2.0f || transform.position.y <= 0.4f || transform.position.z > firstPos.z + 4.0f || transform.position.z < firstPos.z-4.0f)
        {
            transform.position = firstPos;
            transform.rotation = firstRot;
            RigidbodyRest();
        }

    }
    public void RigidbodyRest()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.mass = 1.0f;
        rigidbody.drag = 0.0f;
        rigidbody.angularDrag = 0.05f;

        if (usingGravity)
            rigidbody.useGravity = true;
        else
            rigidbody.useGravity = false;

        rigidbody.isKinematic = false;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }  
}
