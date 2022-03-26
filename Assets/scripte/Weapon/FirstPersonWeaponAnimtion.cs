using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonWeaponAnimtion : MonoBehaviour
{
    Weapon _weapon;
    WeaponAmmo _weaponAmmo;
    Animator _animator;
  [SerializeField]  movement _movement;
    bool _isAming;
    void Start()
    {
       // _movement = FindObjectOfType<movement>();
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInParent<Weapon>();
        _weaponAmmo = GetComponentInParent<WeaponAmmo>();
        _weapon.onFire += Weapon_onFire;
        _weaponAmmo.OnReloadEmetyChanged += _weaponAmmo_OnReloadChanged;
        _weaponAmmo.OnReloadFullChanged += _weaponAmmo_OnReloadAmmoLeftChanged;
        _movement.move += _movement_move;

    }
    private void OnEnable()
    {
       
    }
   
    private void _movement_move(float arg1, float arg2)
    {
        _animator.SetFloat("x", arg1);
        _animator.SetFloat("y", arg2);
    }

    private void _weaponAmmo_OnReloadAmmoLeftChanged()
    {
        _animator.Play("Reload Ammo Left");
    }

    private void _weaponAmmo_OnReloadChanged()
    {
        _animator.Play("Reload Out Of Ammo");
    }

    private void Weapon_onFire()
    {
        _animator.SetTrigger("fire");
      
    }
    //Reload Out Of Ammo

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isAming = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _isAming = !_isAming;
        }
        
        _animator.SetBool("Aim", _isAming);
    }
}
