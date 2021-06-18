using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationRest : MonoBehaviour
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
        if (gameObject.transform.position.x > 5.0f || gameObject.transform.position.y > 5.0f || gameObject.transform.position.z > 5.0f)
        {
            gameObject.transform.position = firstPos;
            gameObject.transform.rotation = firstRot;
            RigidbodyRest();
        }

        
        if(usingGravity)
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
            float velocity_y = rigidbody.velocity.y; 
            rigidbody.velocity = new Vector3(0, velocity_y, 0);
            rigidbody.angularVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>(); 
            rigidbody.velocity = new Vector3(0, 0, 0);
            rigidbody.angularVelocity = new Vector3(0, 0, 0);
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
