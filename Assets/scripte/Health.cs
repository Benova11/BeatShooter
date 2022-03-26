using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _health =5;

    int _currentHealth;
  

    public event Action OnTookHit = delegate { };
    public event Action OnDie = delegate { };
    public event Action<int,int> onHealthChancged = delegate { };
    private void OnEnable()
    {
        _currentHealth = _health;
        if (GetComponent<zombieNav>())GetComponent<zombieNav>().enabled = true;
      
    }
    private void Start()
    {
        onHealthChancged(_currentHealth, _health);
    }

    public void takeHit(int amount)
    {
        modifyHealth(-amount);
        

        if (_currentHealth > 0)
        {

            OnTookHit();
           
         
        }
        else
        {
            OnDie();
//            GetComponent<Collider>().enabled = false;
//            GetComponent<Animator>().enabled = false;

        }
    }

    public void modifyHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _health);
        onHealthChancged(_currentHealth, _health);
    }


}