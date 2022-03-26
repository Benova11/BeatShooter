using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponRaycast : WeaponComponet
{
    
    [SerializeField]  float maxDistance =100;
    [SerializeField]  LayerMask layerMask;
    [SerializeField] polledMonoBehaviour deaclPreab;
    [SerializeField] polledMonoBehaviour bloodPreab;
    [SerializeField] polledMonoBehaviour WallbloodPreab;
    [SerializeField] polledMonoBehaviour CurrentDecalToSpown;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletForce = 500f;
    public List<GameObject> _gameObjects = new List<GameObject>();
    protected override void WeaponFired()
    {
        RaycastHit[] hitInfo;
        //Ray ray = _weapon.isInAimMode ? Camera.main.ViewportPointToRay(Vector3.one / 2): new Ray(firePoint.position,firePoint.forward);
        Ray ray =  Camera.main.ViewportPointToRay(Vector3.one / 2 /* UnityEngine.Random.Range(0.98f,1.02f)*/);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, maxDistance, layerMask);

        CurrentDecalToSpown = bloodPreab;
        
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit Hit = hits[i];
            _gameObjects.Add(hits[i].collider.gameObject);
            Health health;
            if (Hit.collider.GetComponent<Rigidbody>())
            {
                var t = Hit.point - transform.position;

                
                Hit.collider.GetComponent<Rigidbody>().AddForce(t * bulletForce);
                if( Hit.collider.GetComponentInParent<Animator>() == null) return;
                Hit.collider.GetComponentInParent<Animator>().enabled = false;
            }
            if (Hit.collider.GetComponentInParent<Health>())
            {
                health = Hit.collider.GetComponentInParent<Health>();
            }
            else
            {
                health = null;
            }

          

            if (health != null)
            {
                CurrentDecalToSpown = bloodPreab;
                health.takeHit(1);
                SpawnDecal(Hit.point, Hit.normal, CurrentDecalToSpown);
                CurrentDecalToSpown = WallbloodPreab;
            }
            else
            {  
               
              
                if (Hit.collider.tag == "cantBePen")
                { 
                    CurrentDecalToSpown = deaclPreab;
                }
                 SpawnDecal(Hit.point, Hit.normal, CurrentDecalToSpown);
            }
            if (Hit.collider.tag == "cacntBePen")
            {
                
                return;
            }
        }

    }

    private void SpawnDecal(Vector3 point, Vector3 normal, polledMonoBehaviour polled)
    {
        var decal = polled.Get<polledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5);
    }
}
