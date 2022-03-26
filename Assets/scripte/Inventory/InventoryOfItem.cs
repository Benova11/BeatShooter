using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOfItem: MonoBehaviour
{
    public itemSlot[] slots = new itemSlot[9];
    [SerializeField] InventoryItem testItem;

    public static InventoryOfItem instance;
    public bool thereIsSapce = true;

    public event Action<itemSlot> OnAddToInventory = delegate { };
    public event Action<itemSlot> OnRemoveFromInventory = delegate { };


    private void Awake() => instance = this;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddItem(testItem);
        }    

    }
    public void AddItem(InventoryItem item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
           
            if (slots[i].IsEmpty)
            {
                slots[i].AddItem(item);
                OnAddToInventory(slots[i]);
                chakeSpace();
                break;
            }
        }
    }

    public void chakeSpace()
    {
        int index = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if ( !slots[i].IsEmpty)
            {
                index++;
            }
            if (index == slots.Length)
            {
                thereIsSapce = false;
            }
            else
            {
                thereIsSapce = true;
            }

        }
    }

    public void RemoveItem(itemSlot item)
    {
        for (int i = 0; i < slots.Length; i++)
        {

            if (slots[i] == item)
            {
                slots[i].RemoveItem();
                OnRemoveFromInventory(slots[i]);
                chakeSpace();
                break;
            }
        }
    }
}
