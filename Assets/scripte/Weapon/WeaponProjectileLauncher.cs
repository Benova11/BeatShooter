using System;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponProjectileLauncher : WeaponComponet
{
    [SerializeField] Projectile ProjectilePrefab;
    [SerializeField] float velocity = 40f;
    private RaycastHit HitInfo;
    [SerializeField] float maxDistance =100;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject firePoint;

    protected override void WeaponFired()
    {
        Vector3 directrion = _weapon.isInAimMode ? getDirection() : firePoint.transform.forward;
        var Projectile = ProjectilePrefab.Get<Projectile>( firePoint.transform.position, Quaternion.Euler(directrion));
        
        Projectile.GetComponent<Rigidbody>().velocity = directrion * velocity;
    }

    private Vector3 getDirection()
    {
        var ray =  Camera.main.ViewportPointToRay(Vector3.one / 2)  ;
        Vector3 Terget = ray.GetPoint(300);
        if (Physics.Raycast(ray, out HitInfo, maxDistance, layerMask))
        {
            Terget = HitInfo.point;
        }

        Vector3 directrion = Terget - transform.position;
        directrion.Normalize();
        return directrion;
    }
}
