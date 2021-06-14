using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGestureController : MonoBehaviour
{
    public float speed = 1.0f;

    protected OVRSkeleton leftSkeleton;
    protected OVRSkeleton rightSkeleton;
    protected List<OVRBone> leftBones;
    protected List<OVRBone> rightBones;
    public List<Gesture> saveGestures;

    public bool startChecked = true;
    public GameObject leftHand;
    public GameObject rightHand;
    protected Gesture preGesture;
    protected Gesture currentGesture;

    public GameObject player;
    public GameObject centerCam;



    private Vector3 centerCamDir;

    void Start()
    {

    }
    protected void MoveForward()
    {
        Vector3 centerCamDir = centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);

    }

    protected void MoveBackward()
    {
        Vector3 centerCamDir = -centerCam.transform.forward;
        centerCamDir.y = 0;
        centerCamDir.Normalize();

        player.transform.Translate(centerCamDir * speed * Time.deltaTime);
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
