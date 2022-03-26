using System;
using UnityEngine;

[System.Serializable]
public class Objective: ScriptableObject
{   
    public string ObjectiveHeadline;
    [TextArea] public string ObjectiveDiscrpsion;
    public Sprite firstImage;
    public Sprite SecondImage;
    public bool MissionAccomplished;
    public ObjectivesReword objectivesReword;

    public event Action<Objective> OnChangeEndQuest;
    public void SetMissionAccomplished()
    {
        MissionAccomplished = true;
        OnChangeEndQuest?.Invoke(this);
        if (objectivesReword == null) return;
        if (objectivesReword.type == TypeOfReword.coins)
        {
            PlayerWallet.instanc.getCoin(objectivesReword.GiveAmount);
        }
        if (objectivesReword.type == TypeOfReword.quest)
        {
            ObjectiveManager.instance.GetingNewObjective(objectivesReword.NextObjective);
        }
        
    }
    private void OnEnable()
    {
        MissionAccomplished = false;
    }
}
