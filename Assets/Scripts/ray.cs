using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))

        {

            //Debug.Log(hit.collider.gameObject.name);

        }

    }
}
