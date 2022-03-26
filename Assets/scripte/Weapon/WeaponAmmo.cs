
using System;
using System.Collections;
using UnityEngine;
public class WeaponAmmo : WeaponComponet
{
    [SerializeField] bool inittyAmmo;
    [SerializeField] int _maxAmmo;
    [SerializeField] int _maxAmmoPerClip;

    public event Action OnAmmoChanged = delegate { };
    public event Action OnReloadEmetyChanged = delegate { };
    public event Action OnReloadFullChanged = delegate { };
    int _ammoInClip;
    int _ammoRemainNotInClip;

    [SerializeField] float TimeBtweenBullet =1;
    public bool InReloadAnimetion { get; private set; }
    [SerializeField] bool _megWeapon;
    bool _inMenu;
    private void Start()
    {
        _ammoInClip = _maxAmmoPerClip;
        _ammoRemainNotInClip = _maxAmmo - _ammoInClip;

        FindObjectOfType<mouseLoocker>().OnCursorVisible += WeaponAmmo_OnCursorVisible;
    }

    private void WeaponAmmo_OnCursorVisible(bool CursorVisible)
    {
        _inMenu = CursorVisible;
    }

    private void Update()
    {
        if (_inMenu) return;
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }
    public bool isAmmoReady()
    {
        if (InReloadAnimetion)
        {
            return false;
        }
        return _ammoInClip > 0;
    }
    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        _ammoInClip--;
        OnAmmoChanged();
    }
    
    IEnumerator Reload()
    {
        InReloadAnimetion = true;
        if (_ammoInClip ==0) OnReloadEmetyChanged();
        if (_ammoInClip > 0) OnReloadFullChanged();
        int ammoMissingFromClip = _maxAmmoPerClip - _ammoInClip;
        int AmmoToMove = Math.Min(ammoMissingFromClip, _ammoRemainNotInClip);
        if (inittyAmmo)
        {
            AmmoToMove = ammoMissingFromClip;
        }
        if (_megWeapon == true)
        {
           

            _ammoInClip += ammoMissingFromClip;
            _ammoRemainNotInClip -= ammoMissingFromClip;
            OnAmmoChanged();
        }
        else
        {
            while (AmmoToMove > 0)
            {
                yield return new WaitForSeconds(TimeBtweenBullet);

                _ammoInClip += 1;
                _ammoRemainNotInClip -= 1;
                OnAmmoChanged();
                AmmoToMove--;
            }
        }
        yield return new WaitForSeconds(2);
        InReloadAnimetion = false ;
    }

    public string GetAmmoText()
    {
        if (inittyAmmo)
        {
            return string.Format("{0}/∞", _ammoInClip, _ammoRemainNotInClip);
        }
        else
        {
            return string.Format("{0}/{1}", _ammoInClip, _ammoRemainNotInClip);
            
        }
    }
}