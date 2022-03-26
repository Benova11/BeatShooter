using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticlesOnImpect : MonoBehaviour
{
    [SerializeField] ProjectileOnImpect _particlePrefab;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        var impect = _particlePrefab.Get<ProjectileOnImpect>(transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

        var health = collision.collider.GetComponent<Health>();
          if (health!=null)
            {
            health.takeHit(1);
            }
    }
}
