using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class AQuest
{
    public string QuestName;
    public int QuestType; // for example 0 for speaking quest, 1 for killing quest ( not working yet), etc...
    public int CountNeeded;
    public int CurrentCount;
    public bool Complete;
    public string Description;
    public int XpReward;
    public string NpcName;
    public string NpcTarget;
    public int Reward; // gold or item ID, depends on Quest type

    public void Increase(int amount)
    {
        CurrentCount = Mathf.Min(CurrentCount + 1, CountNeeded);

        if (CurrentCount >= CountNeeded && Complete != true)
        {
            Complete = true;
            Debug.Log("Q goal complete");
        }
    }
    
}
