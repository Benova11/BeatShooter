using UnityEngine;
using System;
using System.Collections;
public class ObjectiveGiver: MonoBehaviour
{
    [SerializeField] Objective objective;

    public void GiveObjective()
    {
        Debug.Log("GiveObjective");
        //StartCoroutine(GiveQuest());
        ObjectiveManager.instance.GetingNewObjective(objective);
    }

   private void OnTriggerEnter(Collider other)
    {
        ObjectiveManager.instance.GetingNewObjective(objective);
    }
}
