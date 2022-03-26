using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{

    [SerializeField] KeyCode weaponHotKey;
    [SerializeField] float fireDelay = 0.25f;
    public KeyCode WeaponHotKey => weaponHotKey;
    public event Action onFire = delegate { };
    public event Action <float> setRicoil = delegate { };
    float fireTimer;
    WeaponAmmo ammo;
    public Sprite Icon;

    public float ricoil;

    bool _inMenu;
    public bool isInAimMode { get { return Input.GetMouseButton(1) == false; } } 

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }
    private void Start()
    {
        FindObjectOfType<mouseLoocker>().OnCursorVisible += Weapon_OnCursorVisible;
    }

    private void Weapon_OnCursorVisible(bool CursorVisible)
    {
        _inMenu = CursorVisible;
    }

    void Update()
    {
        if (_inMenu == true) return;
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (canFire())
            {
                fire();
            }
        }
    }

     void fire()
    {
        fireTimer = 0;
        onFire();
        setRicoil(ricoil);
       
    }

     bool canFire()
    {
        if (ammo != null && ammo.isAmmoReady() == false)
        {
            return false;
        }
        return fireTimer > fireDelay;
    }
}
