using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCquest : NPC
{
    public Quest[] QuestList;

    private bool noQuest;

    private int questIndex;

    //public GameObject mark; 

    private int QuestIndex
    {
        get { return questIndex; }
        set
        {
            if (value >= QuestList.Length)
                noQuest = true;
            else
                noQuest = false;
            questIndex = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        SetQuestIndex();
        SetMark();
    }

    private void SetQuestIndex()
    {
        int index = 0;
        for (int i = 0; i < QuestList.Length; i++)
        {
            if (!QuestList[i].state.Equals(QuestState.Complete))
            {
                index = i;
                break;
            }
            if (i.Equals(QuestList.Length - 1))
            {
                index = QuestList.Length;
            }
        }
        QuestIndex = index;
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
