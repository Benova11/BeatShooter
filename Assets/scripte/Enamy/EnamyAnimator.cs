using UnityEngine;



public enum ZombieType
{
    Normal, Crawling,Boss
}
public class EnamyAnimator: MonoBehaviour
{
    Animator _animator;
    [SerializeField] ZombieType _type;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        GetComponent<Health>().OnTookHit += EnamyAnimator_OnTookHit;
        GetComponent<Health>().OnDie += EnamyAnimator_OnDie;
        GetComponent<ZombieAttack>().onAttack += EnamyAnimator_onAttack;
        if(GetComponent<zombieNav>()) GetComponent<zombieNav>().canNotBeMove += EnamyAnimator_canNotBeMove;
    }

    private void EnamyAnimator_canNotBeMove(bool CanNotBeMove)
    {
      if (CanNotBeMove)
        {
            Debug.Log("CanNotDoNot");
        }
        else
        {
            Debug.Log("Catch him");
        }
    }

    private void Start()
    {
        if (_type == ZombieType.Crawling)
        {
            _animator.SetBool("Crawling", true);
        }
    }

    private void EnamyAnimator_onAttack()
    {
        var RandomNam = Random.Range(1, 6);
        _animator.SetInteger("attackId", RandomNam);
        _animator.SetTrigger("attack");
    }

    private void EnamyAnimator_OnDie()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int x = 0; x < transform.GetChild(i).childCount; x++)
            {
                var rb = transform.GetChild(x).GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(Vector3.forward);
                }
            }
        }
        _animator.SetTrigger("die");
      
    }

    private void EnamyAnimator_OnTookHit()
    {
        _animator.SetTrigger("Hit");
    }
}
