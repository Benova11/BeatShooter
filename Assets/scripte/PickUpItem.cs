using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PickUpItem : MonoBehaviour
{

    [SerializeField] Item _item;
    static HashSet<PickUpItem> itemToPick = new HashSet<PickUpItem>();
    private IMet[] _allConditions;

    public static event Action<bool> onItemPickitUp = delegate { };
    public static IReadOnlyCollection<PickUpItem> InspectablesInRange => itemToPick;


    private void Awake()
    {
        _allConditions = GetComponents<IMet>();

    }
    public bool GetMeetsConditions()
    {

        foreach (var Conditions in _allConditions)
        {
            if (Conditions.Met() == false)
            {
                return false;
            }
        }
        return true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GetMeetsConditions())
        {
            itemToPick.Add(this);
            onItemPickitUp?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            if (itemToPick.Remove(this))
            {
                onItemPickitUp?.Invoke(itemToPick.Any());
            }
        }
    }

    public void Inspect()
    {
        itemToPick.Add(this);
        _item.EventOnPick?.Invoke();

        Destroy(gameObject,0.11f);
        itemToPick.Remove(this);
        onItemPickitUp?.Invoke(itemToPick.Any());

        if (_item.Type == type.audio)
        {
            InventoryAudioLog.insance.pickUpAudioLog(_item);
        }
    }

}
