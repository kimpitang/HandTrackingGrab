using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapPosition : OVRGrabbable
{
    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        
        if(m_grabbedCollider.tag.Equals("Tool"))
        {
            if(m_grabbedBy.tag.Equals("LeftHand"))
            {
                m_grabbedCollider.transform.position = m_grabbedBy.transform.position + new Vector3(0.05f, 0.05f, 0.06f);
                m_grabbedCollider.transform.rotation = m_grabbedBy.transform.rotation * Quaternion.Euler(0, 90, 90);
            }
            else if(m_grabbedBy.tag.Equals("RightHand"))
            {
                m_grabbedCollider.transform.position = m_grabbedBy.transform.position + new Vector3(-0.05f, 0.05f, 0.06f);
                m_grabbedCollider.transform.rotation = m_grabbedBy.transform.rotation * Quaternion.Euler(0, 270, 270);
            }

        }
        else if(m_grabbedCollider.tag.Equals("NPC_part"))
        {
            if (m_grabbedBy.tag.Equals("LeftHand"))
            {
                m_grabbedCollider.transform.position = m_grabbedBy.transform.position + new Vector3(0, -0.06f, 0.08f);
                m_grabbedCollider.transform.rotation = m_grabbedBy.transform.rotation * Quaternion.Euler(0, 0, 90);
            }
            else if (m_grabbedBy.tag.Equals("RightHand"))
            {
                m_grabbedCollider.transform.position = m_grabbedBy.transform.position + new Vector3(0, -0.06f, 0.08f);
                m_grabbedCollider.transform.rotation = m_grabbedBy.transform.rotation * Quaternion.Euler(0, 0, 90);
            }
        }
        
    }
}
