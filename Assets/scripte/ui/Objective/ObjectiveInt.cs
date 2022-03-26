using System;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName ="new objective int")]
public class ObjectiveInt: Objective
{

    public int RequiredQuantity;
    public int CurrentQuantity;
    public event Action<ObjectiveInt> OnChange;

    private void OnEnable()
    {
        CurrentQuantity = default;
        MissionAccomplished = default;


    }

    private void OnDisable()
    {
        CurrentQuantity = default;
        MissionAccomplished = default;
    }

    public void Modify()
    {
        CurrentQuantity++;
        if (CurrentQuantity >= RequiredQuantity)
        {
            SetMissionAccomplished();
        }
        OnChange?.Invoke(this);
    }

}
