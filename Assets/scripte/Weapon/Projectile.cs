using System;
using System.Collections;
using UnityEngine;

public class Projectile : polledMonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        gameObject.SetActive(false);
    }
}

   
