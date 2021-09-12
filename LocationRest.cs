using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationRest : MonoBehaviour
{

    private bool isKinematic;
    private Vector3 firstPos;
    private Quaternion firstRot;

    void Start()
    {

        firstPos = gameObject.transform.localPosition;
        firstRot = gameObject.transform.localRotation;
        isKinematic = gameObject.GetComponent<Rigidbody>().isKinematic;
        
    }


    
    void Update()
    {
        if (gameObject.transform.localPosition.y<=-0.6)
        {
            gameObject.transform.localPosition = firstPos;
            gameObject.transform.localRotation = firstRot;
            VelocityRest();
        }

    }
    public void VelocityRest()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        rigidbody.isKinematic = isKinematic;
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }

}
