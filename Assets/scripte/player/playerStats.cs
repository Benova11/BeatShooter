using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{

    [SerializeField] float _maxWater =100;
    float _currentWater;
    [SerializeField] float _maxFood = 100;
    float _currentFood ;

    private Health _playerHealth;

     int _ammountOfWaterToReduceOrAdd = -1;
     int _ammountOfFoodToReduceOrAdd = -1;
    public static playerStats instanc;
    public event Action<float,float,float,float> OnStatChance = delegate { };

    float timer;
    private float _timeBeckToNormal =4f;

    private void Awake()
    {
        instanc = this;
        _currentFood = _maxFood;
        _currentWater = _maxWater;
        _playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            reduceOrAddWater(_ammountOfWaterToReduceOrAdd);
            reduceOrAddFood(_ammountOfFoodToReduceOrAdd);
            timer = 0;
            OnStatChance(_maxWater, _currentWater, _maxFood, _currentFood);
          
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(ammountOfWaterToReduce(-12));
        }
    }

    public void AmmountOfFoodToReduce(int ammountToGive)
    {
        StartCoroutine(ammountOfFoodToReduce(ammountToGive));
    }

    public void AmmountOfWaterToReduce(int v)
    {
        StartCoroutine(ammountOfWaterToReduce(v));
    }

    IEnumerator ammountOfWaterToReduce(int Ammount)
    {
        _ammountOfWaterToReduceOrAdd = Ammount;
        yield return new WaitForSeconds(_timeBeckToNormal);
        SetammountOfWaterToReduceToNormal();
    }

    IEnumerator ammountOfFoodToReduce(int Ammount)
    {
        _ammountOfFoodToReduceOrAdd = Ammount;
        yield return new WaitForSeconds(_timeBeckToNormal);
        SetammountOfFoodToReduceToNormal();
    }

    public void SetammountOfWaterToReduceToNormal()
    {
        _ammountOfWaterToReduceOrAdd = -1;
    }  
    public void SetammountOfFoodToReduceToNormal()
    {
        _ammountOfFoodToReduceOrAdd = -1;
    }





    public void reduceOrAddWater(int ammount)
    {
        _currentWater += ammount;
        _currentWater= Mathf.Clamp(_currentWater, 0, _maxWater);    
        if (_currentWater <= 0)
        {
            _playerHealth.takeHit(1);
        }
        
    }  
    public void reduceOrAddFood(int ammount)
    {
        _currentFood += ammount;
        _currentFood = Mathf.Clamp(_currentFood, 0, _maxFood);
        if (_currentFood <= 0)
        {
            _playerHealth.takeHit(1);
        }


    }
}
