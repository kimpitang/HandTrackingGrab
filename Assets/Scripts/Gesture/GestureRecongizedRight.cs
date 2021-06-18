using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class GestureRecongizedRight : MonoBehaviour
{

    protected OVRSkeleton rightSkeleton;
    protected List<OVRBone> rightBones;
    public List<Gesture> saveGestures;

    public GameObject rightHand;
    protected Gesture preGesture;
    protected Gesture currentGesture;

    void Start()
    {
        LoadData();
        rightSkeleton = rightHand.GetComponent<OVRSkeleton>();
        preGesture = new Gesture("preGesture");
    }

    void FixedUpdate()
    {   
        rightBones = new List<OVRBone>(rightSkeleton.Bones);
        currentGesture = Recognized();
        

        if (!currentGesture.name.Equals("checked"))
        {
            Debug.Log("Right Gesture: " + currentGesture.name);

            if(currentGesture.name.Equals("Right_back_v1")|| currentGesture.name.Equals("Right_back_v2"))
            {
                GameObject.FindWithTag("GR").GetComponent<GestureAction>().GoBack();
            }

            if (!preGesture.name.Equals("Right_thumb") && currentGesture.name.Equals("Right_thumb"))
            {
                //GameObject.Find("Panel").GetComponent<FirstNpcDialog>().nextdialogok = true;
            }
            else
            {
                //GameObject.Find("Panel").GetComponent<FirstNpcDialog>().nextdialogok = false;
            }

            if(currentGesture.name.Equals("Right_rock_v1") || currentGesture.name.Equals("Right_rock_v2"))
            {
                print("right rock");
                GameObject rightHand = GameObject.FindWithTag("RightHand");
                rightHand.GetComponent<GrabRight>().GrabStart();
            }

            if(!currentGesture.name.Equals("Right_rock_v1"))
            {
                if (!currentGesture.name.Equals("Right_rock_v2"))
                {
                    GameObject rightHand = GameObject.FindWithTag("RightHand");
                    rightHand.GetComponent<GrabRight>().GrabFinish();
                } 
            }
            
            preGesture = currentGesture;
        }
        else
        {
            GameObject rightHand = GameObject.FindWithTag("RightHand");
            rightHand.GetComponent<GrabRight>().GrabFinish();
        }
    }

    public void LoadData()
    {
        string jsondata = File.ReadAllText(Application.dataPath + "/Scripts/Gesture/rightdata.json");
        var datas = JsonHelper.FromJson<Data>(jsondata);


        for (int i = 0; i < datas.Length; i++)
        {
            Gesture addGesture = new Gesture(datas[i].gesturename);
            List<Vector3> checkedPosition = new List<Vector3>();
            for (int j = 0; j < datas[i].bonepositions.Length; j++)
            {
                checkedPosition.Add(datas[i].bonepositions[j]);
            }
            addGesture.SetPosition(checkedPosition);
            saveGestures.Add(addGesture);
        }
    }

    private Gesture Recognized()
    {

        float checkedDist = 0.05f;
        float minDist = Mathf.Infinity;
        Gesture checkedGesture = new Gesture("checked");

        foreach (var saveGesture in saveGestures)
        {
            bool discardGesture = false;
            float sumDist = 0.0f;
            for (int i = 2; i < rightBones.Count; i++)
            {
                Vector3 pos = rightHand.transform.InverseTransformPoint(rightBones[i].Transform.position);
                float distance = Vector3.Distance(saveGesture.positions[i], pos);

                if (distance > checkedDist)
                {
                    discardGesture = true;
                    break;
                }
                sumDist += distance;
            }

            if (!discardGesture && sumDist < minDist)
            {
                checkedGesture = saveGesture;
                minDist = sumDist;
            }
        }
        return checkedGesture;
    }
}