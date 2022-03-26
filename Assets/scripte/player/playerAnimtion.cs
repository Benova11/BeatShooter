using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimtion : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float drawWeaponSpeed;
    [SerializeField] float delayBefoe =3;

    Coroutine currentFafeRoutine;

   
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentFafeRoutine != null)
            {
                StartCoroutine(FadeToShootingLayer());
            }
            currentFafeRoutine = StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetButtonUp("Fire1"))
        {

            currentFafeRoutine = StartCoroutine(FadeFromShootingLayer());
        }
    }

     IEnumerator FadeFromShootingLayer()
    {
        yield return currentFafeRoutine;
        yield return new WaitForSeconds(delayBefoe);
        var currentWeight = _animator.GetLayerWeight(1);
        float elapsed = 0;
        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            _animator.SetLayerWeight(1, currentWeight);
            yield return null;
        }
        _animator.SetLayerWeight(1, 0);
    }

    private IEnumerator FadeToShootingLayer()
    {
        var currentWeight = _animator.GetLayerWeight(1);
        float elapsed = 0;
        while(elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            _animator.SetLayerWeight(1,currentWeight);
             yield return null;
        }

        _animator.SetLayerWeight(1, 1);
    }

    public void SetAnimatorOverrideController(AnimatorOverrideController curWeaponAnimaion)
    {
        _animator.runtimeAnimatorController = curWeaponAnimaion;
    }
}
