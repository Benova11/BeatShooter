using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    public InventoryItem _item;

    [SerializeField] Image _icon;
    public bool IsEmpty = true;

    private void Awake()
    {

        _icon = transform.GetChild(0).GetComponent<Image>();

        _icon.enabled = false;
        _icon.sprite = null;
    }
    public void AddItem(InventoryItem item)
    {
        _item = item;
        IsEmpty = false;
        _icon.enabled = true;
        _icon.sprite = _item.icon;
    }
    public void RemoveItem()
    {
        _icon.enabled = false;
        _icon.sprite = null;
        IsEmpty = true;
        _item = null;
    }
}
