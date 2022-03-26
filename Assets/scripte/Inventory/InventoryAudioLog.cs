using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAudioLog : MonoBehaviour
{
    public List<Item> AudioLogInInventory = new List<Item>();
    public event Action OnPickitAudioLog = delegate { };
    public static InventoryAudioLog insance;

    
    private void Awake()
    {
        insance = this;
    }
    public void pickUpAudioLog(Item item)
    {
        AudioLogInInventory.Add(item);
        OnPickitAudioLog();
    }

    
}
