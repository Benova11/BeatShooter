using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public static PlayerWallet instanc;

    [SerializeField] int currentCoinsInMyWallet = 0;
    private void Awake()
    {
        instanc = this;
    }

    public void getCoin(int coin)
    {
        currentCoinsInMyWallet += coin;
    }
}
