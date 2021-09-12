using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDetector : MonoBehaviour
{
    public PartActive partActive;

    private GameObject[] pointers;

    void Start()
    {
        pointers = GameObject.FindGameObjectsWithTag("Pointer");
        foreach (GameObject pointer in pointers)
        {
            pointer.SetActive(false);
        }
    }


    public void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.gameObject.tag == "NPC_part")
        {
            Debug.Log("Part check!!");
            GameObject npc_part = GameObject.FindWithTag("NPC_part");
            OVRGrabbable npc_grabble = npc_part.GetComponent<OVRGrabbable>();
            OVRGrabber npc_grabber = npc_grabble.grabbedBy;
            GameObject leftHand = GameObject.FindWithTag("LeftHand");
            GameObject rightHand = GameObject.FindWithTag("RightHand");

            if (npc_grabber.gameObject == leftHand)
            {
                npc_part.GetComponent<PartDestroy>().SetDestroy("LeftHand");
            }
            if (npc_grabber.gameObject == rightHand)
            {
                npc_part.GetComponent<PartDestroy>().SetDestroy("RightHand");
            }

            foreach (GameObject pointer in pointers)
            {
                pointer.SetActive(true);
            }
            partActive.FixedArm();

        }


    }

}
