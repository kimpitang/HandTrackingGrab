using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbable : OVRGrabbable
{
    //private ObjController objController;

    protected override void Start()
    {
        base.Start();
        //objController = GetComponent<ObjController>();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        //GetComponent<ObjController>().OnGrabEnd();
    }
}
