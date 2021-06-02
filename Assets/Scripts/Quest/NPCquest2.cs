using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCquest2 : NPC
{
    public Quest Quest;

    private bool noQuest;

    //public GameObject mark; 

    protected override void Awake()
    {
        base.Awake();
        SetMark();
    }

    public void AcceptQuest(Quest quest)
    {
        GameManager.Instance.SetCurrnetQuest(quest);
    }

    public void SetMark()
    {
        if (!noQuest)
        {
            mark.gameObject.SetActive(true);
        }
        else
        {
            mark.gameObject.SetActive(false);
        }
    }
}

