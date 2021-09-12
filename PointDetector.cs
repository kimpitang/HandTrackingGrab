using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetector : MonoBehaviour
{
    public PartActive partActive;
    


    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.tag == "Tool")
        {
            Destroy(gameObject);
            partActive.DeleteCount();
        }

    }
}
