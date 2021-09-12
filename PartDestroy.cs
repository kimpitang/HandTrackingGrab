using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDestroy : MonoBehaviour
{
    public void ObjectDestroy()
    {
        Vector3 disappearedPlace = new Vector3(0.0f,-10.0f,0.0f);

        transform.position = disappearedPlace;
    }
}
