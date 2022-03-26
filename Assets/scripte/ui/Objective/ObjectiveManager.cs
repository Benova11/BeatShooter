using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveManager: MonoBehaviour
{
    public event Action<Objective> OnGetingNewObjective = delegate { };
    public event Action OnEndingObjective = delegate { };

    public static ObjectiveManager instance;
    [SerializeField] Objective _objective;
    [SerializeField] Objective _firstObjective;
    [SerializeField] Objective _objectiveForTest;
    public static List<Objective> _listOfQuest = new List<Objective>();
    public List<Objective> listOfQuest = new List<Objective>();
    public Objective CurObjective => _objective;
    private void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        GetingNewObjective(_firstObjective);
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("lats go new quest");
            GetingNewObjective(_objectiveForTest);
        }
    }

    public void GetingNewObjective(Objective objective)
    {
        _listOfQuest.Add(objective);
        listOfQuest.Add(objective);
         OnGetingNewObjective(_objective);
         OnEndingObjective?.Invoke();
          objective.OnChangeEndQuest += Objective_OnChangeEndQuest;
    }

    private void Objective_OnChangeEndQuest(Objective obj)
    {
        OnEndingObjective();
    }
}
