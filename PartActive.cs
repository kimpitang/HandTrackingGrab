using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PartActive : MonoBehaviour
{
    private GameObject leftArm;
    private int pointCount;

    public UnityEvent ActiveEvent;

    [SerializeField] private GameObject perfectRobot;

    void Start()
    {
        leftArm = gameObject.transform.GetChild(9).gameObject;
        leftArm.gameObject.SetActive(false);
        pointCount = 3;
    }


    void Update()
    {

    }

    public void FixedArm()
    {
        leftArm.gameObject.SetActive(true);
        ActiveEvent.Invoke();
    }

    public void DeleteCount()
    {
        pointCount--;
        if (pointCount == 0)
        {
            Restore();
        }
    }


    public void Restore()
    {
        ActiveEvent.Invoke();
        perfectRobot.SetActive(true);
        Destroy(gameObject);
        
    }
}

