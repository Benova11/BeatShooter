using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponMuzzleFlash: WeaponComponet
{
    [SerializeField] GameObject _muzzleFlash;


    private IEnumerator StartmuzzleFlash()
    {
        _muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _muzzleFlash.SetActive(false);
    }

    protected override void WeaponFired()
    { 
        StartCoroutine(StartmuzzleFlash());  
        
    }
}
