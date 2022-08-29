using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    public int amountNeeded = 10;
    public int buyPrice = 2;
    public int depletionValue = 1;

    private void Awake()
    {
        instance = this;
    }

    public int KerosineDecrease(int depletionValue)
    {
        if (amountNeeded > 0 && KeroseneSpawn.instance.playerKerosene >= 10)
        {
            amountNeeded -= depletionValue;

            if (amountNeeded == 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("not enough kerosine");
        }
        return amountNeeded;
    }

    public int SellKerosine(int buyPrice)
    {
        if(KeroseneSpawn.instance.playerKerosene >= 10)
        {
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney += buyPrice);

            PlayerMoney.instance.UpdatePlayerMoney();

            Debug.Log("selling");
        }
        return buyPrice;
    }
}
