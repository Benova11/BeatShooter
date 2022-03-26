using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class uiAmmoText : MonoBehaviour
{
    [SerializeField] TMP_Text _textAmmo;
   
    private WeaponAmmo _curWeaponAmmo;

    private void Awake()
    {
        _textAmmo = GetComponent<TMP_Text>();
        Inventory.onWeaponChanged += Inventory_onWeaponChanged; 
    }

    private void Inventory_onWeaponChanged(Weapon weapon)
    {
      
        _curWeaponAmmo = weapon.GetComponent<WeaponAmmo>();

        if (_curWeaponAmmo != null)
        {
            _curWeaponAmmo.OnAmmoChanged -= _curWeaponAmmo_OnAmmoChanged;
        }

        if (_curWeaponAmmo != null)
        {
            _curWeaponAmmo.OnAmmoChanged += _curWeaponAmmo_OnAmmoChanged;
            _textAmmo.text = _curWeaponAmmo.GetAmmoText();
        }
        else
        {
            _textAmmo.text = "&&";
        }
    }

    private void _curWeaponAmmo_OnAmmoChanged()
    {
        _textAmmo.text = _curWeaponAmmo.GetAmmoText();
    }
}

