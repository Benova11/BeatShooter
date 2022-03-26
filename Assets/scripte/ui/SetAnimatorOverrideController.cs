using UnityEngine;

public class SetAnimatorOverrideController : MonoBehaviour
{
    private WeaponAnimatorOverrideController _curWeaponAnimaion;

    private void Awake()
    {
        
        Inventory.onWeaponChanged += Inventory_onWeaponChanged;
    }

    private void Inventory_onWeaponChanged(Weapon weapon)
    {
        var playerAnimtion = GetComponent<playerAnimtion>();
        _curWeaponAnimaion = weapon.GetComponent<WeaponAnimatorOverrideController>();
        playerAnimtion.SetAnimatorOverrideController(_curWeaponAnimaion.animatorOverrideController);
    }
}

