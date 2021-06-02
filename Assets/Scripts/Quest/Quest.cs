using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    Startable,
    Progressing,
    Completable,
    Complete
}

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public QuestState state = QuestState.Startable;
    public int questNum;
    public string questName;

    [TextArea(2, 6)]
    public string questText, completeText;

    public bool QuestCompleteCondition;

    /*
    public CollectObjective[] collectObjectives;

    public bool IsCompleteObjectives
    {
        get
        {
            foreach (var o in collectObjectives)
            {
                if (!o.IsComplete)
                    return false;
            }
            return true;
        }
    }
    */

    public Rewards rewards;
}

[Serializable]
public abstract class Objective
{

    public Item item;
    public int amount;
    public int currentAmount { get; set; }

    public bool IsComplete { get { return currentAmount >= amount; } }
}

/*
[Serializable]
public class CollectObjective : Objective
{
 
    public void UpdateItemCount()
    {
        currentAmount = Inventory.Instance.GetItemCount(item);
    }
}
*/

[Serializable]
public class Rewards
{
    public Item item;
    public int count;

}