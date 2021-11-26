using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrabbable : OVRGrabbable
{
    private Vector3 handVelocityCross;
    private Vector3[] velocityFrames;
    private Vector3[] angularVelocityFrames;
    private int currentVelociryFrameStep;
    protected override void Start()
    {
        base.Start();
        velocityFrames = new Vector3[5];
        angularVelocityFrames = new Vector3[5];
        currentVelociryFrameStep = 0;
    }

    public void SetHandVelocityCross(Vector3 cross)
    {
        handVelocityCross = cross;
    }

    void FixedUpdate()
    {
        VelocityUpdate();
    }

    void VelocityUpdate()
    {
        
        if (velocityFrames != null)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            print("velocityFrames is exist!!");
            currentVelociryFrameStep++;
            if (currentVelociryFrameStep >= velocityFrames.Length)
            {
                currentVelociryFrameStep = 0;
            }

            velocityFrames[currentVelociryFrameStep] = rb.velocity;
            angularVelocityFrames[currentVelociryFrameStep] = rb.angularVelocity;
        }
    }

    private Vector3 GetVectorAverge(Vector3[] vector)
    {
        int size = vector.Length;
        float sum_x = 0.0f;
        float sum_y = 0.0f;
        float sum_z = 0.0f;
        for(int i = 0; i < size; i++)
        {
            sum_x += vector[i].x;
            sum_y += vector[i].y;
            sum_z += vector[i].z;
        }

        float averge_x = sum_x / size;
        float averge_y = sum_y / size;
        float averge_z = sum_z / size;

        Vector3 averge = new Vector3(averge_x,averge_y,averge_z);

        return averge;
    }

    void AddVelocityHistory()
    {
        if (velocityFrames != null)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 velocityAverge = GetVectorAverge(velocityFrames);
            if(velocityAverge != null)
            {
                rb.velocity = velocityAverge;
            }

            Vector3 angularVelocityAverge = GetVectorAverge(angularVelocityFrames);
            if(angularVelocityFrames != null)
            {
                rb.angularVelocity = angularVelocityAverge;
            }
        }
    }

    void ResetVelocityHistory()
    {
        currentVelociryFrameStep = 0;
        if(velocityFrames != null && velocityFrames.Length > 0)
        {
            velocityFrames = new Vector3[velocityFrames.Length];
            angularVelocityFrames = new Vector3[velocityFrames.Length];
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Vector3 fullThrowVelocity = linearVelocity + handVelocityCross;
        rb.isKinematic = m_grabbedKinematic;
        rb.velocity = fullThrowVelocity;
        rb.angularVelocity = angularVelocity;
        AddVelocityHistory();
        ResetVelocityHistory();
        m_grabbedBy = null;
        m_grabbedCollider = null;
    }



}
