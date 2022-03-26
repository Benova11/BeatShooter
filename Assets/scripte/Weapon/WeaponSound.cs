using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponet
{

    [SerializeField]simpleAduioEvent shootingSound;
    [SerializeField]simpleAduioEvent ReloadAmmoLeftSound;
    [SerializeField]simpleAduioEvent ReloadOutOfAmmoSound;
  
    AudioSource _audioSource;
    WeaponAmmo _weaponAmmo;
 
    private void Start()
    {      
        _audioSource = GetComponent<AudioSource>();
        _weaponAmmo = GetComponent<WeaponAmmo>();
        _weaponAmmo.OnReloadEmetyChanged += _weaponAmmo_OnReloadEmetyChanged;
        _weaponAmmo.OnReloadFullChanged += _weaponAmmo_OnReloadFullChanged;
    }

    private void _weaponAmmo_OnReloadFullChanged()
    {
        ReloadAmmoLeftSound.Play(_audioSource);
    }

    private void _weaponAmmo_OnReloadEmetyChanged()
    {
        ReloadOutOfAmmoSound.Play(_audioSource);
    }

    protected override void WeaponFired()
    {
        shootingSound.Play(_audioSource);
    }
}
