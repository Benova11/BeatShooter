using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

   [SerializeField] Weapon[] _weapons;
    public static event Action<Weapon> onWeaponChanged = delegate { };


    private void Start()
    {
        SwtichToWeapon(_weapons[0]);
    }

    void Update()
    {
     
        foreach (var weapon in _weapons)

        {
            
            if (Input.GetKeyDown(weapon.WeaponHotKey))
            {
               
                SwtichToWeapon(weapon);
                break;
            }
        }
    }

     void SwtichToWeapon(Weapon weaponToSwtichTo)
    {
        foreach (var weapon in _weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwtichTo);

        }
        onWeaponChanged(weaponToSwtichTo);
    }
}
