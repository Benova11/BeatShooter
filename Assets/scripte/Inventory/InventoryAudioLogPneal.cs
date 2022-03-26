using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class InventoryAudioLogPneal: WindowsManager
{
   [SerializeField] GameObject prefab;
   [SerializeField] Transform canvesPernt;

    InventoryAudioLog _inventoryAudioLog;
    List<Item> ItemInInventory = new List<Item>();

    void OnEnable()   
    {
       
        _inventoryAudioLog = InventoryAudioLog.insance;
        _inventoryAudioLog.OnPickitAudioLog  += InventoryAudioLogPneal_OnPickitAudioLog;     
    }
    private void Start()
    {
        CloseWindow();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isVisble) OpneWindow();
            else CloseWindow();
        }
    }

    private void InventoryAudioLogPneal_OnPickitAudioLog()
    {

        foreach (var AudioLog in _inventoryAudioLog.AudioLogInInventory)
        {
            if (!ItemInInventory.Contains(AudioLog))
            {
                ItemInInventory.Add(AudioLog);
                var slot = Instantiate(prefab);
                slot.AddComponent(typeof(Button));
                Button slotButton = slot.GetComponent<Button>();
                slotButton.onClick.AddListener(() => opneToolTipWindow(AudioLog));
                slot.transform.SetParent(canvesPernt);
                slot.GetComponentInChildren<TMP_Text>().SetText(AudioLog.itemName);
            }
        }
    }


    private void opneToolTipWindow(Item AudioLog)
    {
        AudioLog.aduioEvent.Play(AudioManager.instcne.setAudioSours());

    }
}
