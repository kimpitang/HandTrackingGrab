using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetector : MonoBehaviour
{

    private bool usingGravity = false;
    public string colliderName;
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

    public void UnGrabbing()
    {
        
        Debug.Log("hand is not grabbing");

        if (colliderName == "Box")
        {
            //boxcollider reset!
            BoxCollider preBoxcollider = gameObject.GetComponent<BoxCollider>();
            Vector3 center = preBoxcollider.center;
            Vector3 size = preBoxcollider.size;

            //Destroy(gameObject.GetComponent<BoxCollider>());
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.center = center;
            boxCollider.size = size;
            boxCollider.isTrigger = false;
            Destroy(preBoxcollider);

        }
        else if(colliderName == "Capsule")
        {
            //Capsule Collider reset!
            CapsuleCollider preCapsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            Vector3 center = preCapsuleCollider.center;
            float radius = preCapsuleCollider.radius;
            //preCapsuleCollider.isTrigger = false;

            
            CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
            capsuleCollider.center = center;
            capsuleCollider.radius = radius;
            capsuleCollider.height = 2;
            capsuleCollider.direction = 1;
            capsuleCollider.isTrigger = false;
            Destroy(preCapsuleCollider);
            
        }
        else
        {
            //sphere reset!
            SphereCollider preSphereCollider = gameObject.GetComponent<SphereCollider>();
            Vector3 center = preSphereCollider.center;
            float radius = preSphereCollider.radius;
            //preSphereCollider.isTrigger = false;

            
            //Destroy(gameObject.GetComponent<SphereCollider>());
            SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
            sphereCollider.center = center;
            sphereCollider.radius = radius;
            sphereCollider.isTrigger = false;
            Destroy(preSphereCollider);
            
        }
    }
}
