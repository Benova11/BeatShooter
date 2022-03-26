using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager instanc;

    private List<NpcType> _npcTypes = new List<NpcType>();
    public Action<int, int, int> passTheNewStat;
    public Action noMoreE;
    public int badP,goodP,cop;
    private void Awake()
    {
        if (instanc != null) Destroy(this);
        instanc = this;
        
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        _npcTypes = FindObjectsOfType<NpcType>().ToList();
        foreach (var npc in _npcTypes)
        {
            npc.OnDie += OnDie;
            switch (npc.Type)
            {
                case NpcType.npcType.Citizen:
                    goodP++;
                    break;
                case NpcType.npcType.Armed:
                    badP++;
                    break;
                case NpcType.npcType.Cop:
                    cop++;
                    break;
               
            }
        }
        yield return new WaitForSeconds(0.5f);
        passTheNewStat?.Invoke(goodP,badP,cop);
    }

    private void OnDisable()
    {
        foreach (var npc in _npcTypes)
        {
            npc.OnDie -= OnDie;
        }
    }

    private void OnDie(NpcType.npcType type, NpcType npc)
    {
        switch (type)
        {
            case NpcType.npcType.Citizen:
                goodP--;
                break;
            case NpcType.npcType.Armed:
                badP--;
                if (badP == 0)
                {
                    noMoreE.Invoke();
                }
                break;
            case NpcType.npcType.Cop:
                cop--;
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
            
        }

        npc.OnDie -= OnDie;

        passTheNewStat?.Invoke(goodP,badP,cop);
    }
}