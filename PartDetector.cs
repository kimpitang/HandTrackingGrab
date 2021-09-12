using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDetector : MonoBehaviour
{
    //Timer 관련 변수
    private bool tool;
    private bool part;
    private float toolTimer;
    private float partTimer;
    private float toolElapsedTime;
    private float partElapsedTime;
    private bool toolTimeEnd;
    private bool partTimeEnd;

    //Tool&Part
    private GameObject ToolObject;
    private GameObject PartObject;

    //Parent Object
    private GameObject parent;

    //Hand


    void Start()
    {
        tool = false;
        part = false;
        toolTimer = 5.0f;
        partTimer = 5.0f;
        toolElapsedTime = 0.0f;
        partElapsedTime = 0.0f;
        toolTimeEnd = false;
        partTimeEnd = false;
        parent = transform.parent.gameObject.transform.parent.gameObject;
        ToolObject = GameObject.FindWithTag("Tool");
        PartObject = GameObject.FindWithTag("NPC_part");
    }

    
    void Update()
    {
        if (tool)
        {
            toolElapsedTime += Time.deltaTime;
            if (toolElapsedTime >= toolTimer)
            {
                toolTimeEnd = true;
                tool = false;
                //Destroy(ToolObject);
            }
        }

        if(part)
        {
            partElapsedTime += Time.deltaTime;
            if(partElapsedTime >= partTimer)
            {
                partTimeEnd = true;
                part = false;
                //Destroy(PartObject);
            }
        }

        if(partTimeEnd&&toolTimeEnd)
        {
            parent.GetComponent<PartActive>().Restore();
            //Destroy(gameObject);
            //Destroy(ToolObject);
            //Destroy(PartObject);
            //PartObject.gameObject.SetActive(false);
            PartObject.GetComponent<PartDestroy>().ObjectDestroy();
        }

    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "NPC_part")
        {
            Debug.Log("Part check!!");
            part = true;
        }

        if(otherCollider.gameObject.tag == "Tool")
        {
            Debug.Log("Tool check!!");
            tool = true;
        }

    }

    public void OnTriggerExit(Collider otherCollider)
    {
        if(otherCollider.gameObject.tag == "NPC_part")
        {
            if(!partTimeEnd)
            {
                part = false;
                partElapsedTime = 0.0f;
            }
        }

        if(otherCollider.gameObject.tag == "Tool")
        {
            if(!toolTimeEnd)
            {
                tool = false;
                toolElapsedTime = 0.0f;
            }
        }
    }
}
