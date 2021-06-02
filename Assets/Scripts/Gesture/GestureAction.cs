using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureAction : MonoBehaviour
{
    public float speed = 1.0f;

    public GameObject player;
    public GameObject centerCam;

    private Vector3 centerCamDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoStraight()
    {
        Vector3 centerCamDir = centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);
    }

    public void GoBack()
    {
        Vector3 centerCamDir = -centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);
    }
}
