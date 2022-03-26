using System;
using System.Collections;
using UnityEngine;
public class ZombieAttack : MonoBehaviour
{
    [Tooltip("time between attacks")]
    [SerializeField] float _delayBetweenAttacks = 1.5f;

    [Tooltip("how far away the zombie can Ataack from")]
    [SerializeField] float _maxAttacksRange = 1.5f;
    [SerializeField] float delayBetweenAnimationToTakeHit = 1.5f;
    [SerializeField] int _damage = 1;
    Health _playerHealth;

    float _attackTimer;

    public event Action onAttack = delegate { };
    private void Start()
    {
        _playerHealth = FindObjectOfType<movement>().GetComponent<Health>();
    }
    private void Update()
    {
        _attackTimer += Time.deltaTime;
        if (canAttack())
        {
            _attackTimer = 0;
            Attack();
        }
    }

    private bool canAttack()
    {
        return _attackTimer >= _delayBetweenAttacks && Vector3.Distance(transform.position, _playerHealth.transform.position)<= _maxAttacksRange;
    }
    private void Attack()
    {
        onAttack();
        StartCoroutine(dealDamageAfterDelay());
    }

    IEnumerator dealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationToTakeHit);
        _playerHealth.takeHit(_damage);
    }
}
