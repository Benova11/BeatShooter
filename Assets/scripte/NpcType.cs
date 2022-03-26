using System;
using UnityEngine;

public class NpcType : MonoBehaviour
{
    public enum npcType
    {
        Citizen,Armed,Cop
    }

    public npcType Type = npcType.Armed;

    public Action<npcType,NpcType> OnDie;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDie += HealthOnOnDie;
    }

    private void HealthOnOnDie()
    {
        OnDie?.Invoke(Type,this);
        switch (Type)
        {
            case npcType.Citizen:
                Debug.Log("you dump ass you killd cv");
                break;
            case npcType.Armed:
                Debug.Log("good job take them all");
                break;
            case npcType.Cop:
                Debug.Log("wayy god way!!!!!!!!!!!!!!!");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}