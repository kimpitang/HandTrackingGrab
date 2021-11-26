using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartActive : MonoBehaviour
{
    private GameObject leftArm;
    private int pointCount;

    [SerializeField] private GameObject perfectRobot;
    [SerializeField] private DecoManager decoManager;
    [SerializeField] private EffectAudioManager effectAudioManager;
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
    }

    public void DeleteCount()
    {
        pointCount--;
        effectAudioManager.PointerFixedEffect();
        if (pointCount == 0)
        {
            Restore();
        }
    }


    public void Restore()
    {
        effectAudioManager.RestoredRobotEffect();
        perfectRobot.SetActive(true);
        decoManager.EndStep1();
        Destroy(gameObject);
        
    }
}

