using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryOfItemUi : MonoBehaviour
{
    List<itemSlot> slots = new List<itemSlot>();

    public Button Use;
    public Button Drop;
    [SerializeField] TMP_Text discripion;
    [SerializeField] GameObject _toolTip;

    movement player;

    private void Awake()
    {
        player = FindObjectOfType<movement>();
    }
    private void Start()
    {
        InventoryOfItem.instance.OnAddToInventory += Instance_OnAddToInventory;
        InventoryOfItem.instance.OnRemoveFromInventory += Instance_OnRemoveFromInventory;
    }

    private void Instance_OnRemoveFromInventory(itemSlot obj)
    {
        if (obj != null)
            slots.Remove(obj);
    }

    private void Instance_OnAddToInventory(itemSlot item)
    {
        if (item != null)
        {
            slots.Add(item);

            item.GetComponent<Button>().onClick.AddListener(() => onClckButton(item));
        }
        
    }

    public void onClckButton(itemSlot item)
    {
        if (item == null) return;
        if (!item.IsEmpty)
        {
            _toolTip.SetActive(true);
            Use.onClick.RemoveAllListeners();
            Drop.onClick.RemoveAllListeners();
            Use.onClick.AddListener(() => use(item));
            Drop.onClick.AddListener(() => RemoveItem(item));
            string rgb1 = item._item.AmmountToGive > 0 ? "green" : "red";
            string rgb2 = item._item.AmmountToTake < 0 ? "red" : "green";

            discripion.SetText(item._item.itemName + ":" + item._item.itemName + "\n" + $"<color={rgb1}>{ item._item.PostiveType.ToString() + ":" + item._item.AmmountToGive} </color>" + $"<color={rgb2}>{ "\n" + item._item.NagtiveType.ToString() + ": " + item._item.AmmountToTake.ToString()} </color>");
        }
    }

    private void RemoveItem(itemSlot item)
    {
        clearSlot( );
        var p = Instantiate(item._item.Prepab);
        p.transform.position = player.transform.position + player.transform.forward;
        InventoryOfItem.instance.RemoveItem(item);
    }

    private void use(itemSlot item)
    {
        item._item.OnUse();
        clearSlot();
        InventoryOfItem.instance.RemoveItem(item);
    }

    private void clearSlot()
    {
        
        _toolTip.SetActive(false);
        Use.onClick.RemoveAllListeners();
        Drop.onClick.RemoveAllListeners();
    }
}
