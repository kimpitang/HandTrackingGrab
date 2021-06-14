using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDestroy : MonoBehaviour
{
    public void ObjectDestroy()
    {
        Vector3 disappearedPlace = new Vector3();
        disappearedPlace = Vector3.zero;

        transform.position = disappearedPlace;
    }
}
