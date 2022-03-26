using UnityEngine;
using UnityEngine.UI;

public class UiGunIcon : MonoBehaviour
{
    Image _icon;

    private void Awake()
    {
        _icon = GetComponent<Image>();
        Inventory.onWeaponChanged += Inventory_onWeaponChanged; 
    }
    private void Inventory_onWeaponChanged(Weapon weapon)
    {
        _icon.sprite = weapon.Icon;
    }

}

