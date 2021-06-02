using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Panel").GetComponent<FirstNpcDialog>().nextdialogok = true;
        //GameObject.Find("Panel").GetComponent<FirstNpcDialog>().nextdialogok = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNext()
    {
        GameObject.Find("Panel").GetComponent<FirstNpcDialog>().NextDialogue();
    }
}
