using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    public int amountNeeded = 10;
    int buyPrice = 50;
    public int depletionValue = 1;

    public bool bucketFull;

    private void Awake()
    {
        instance = this;
        bucketFull = false;
    }

    public int KerosineDecrease(int depletionValue)
    {
        int currentValue = PlayerPrefs.GetInt("AmountOfKerosene");

        if (amountNeeded > 0 && currentValue >= amountNeeded)
        {
            amountNeeded -= depletionValue;

            Debug.Log(amountNeeded);
            Debug.Log(PlayerMoney.instance.playerMoney + " before");

            if (amountNeeded <= 0)
            {
                gameObject.SetActive(false);
            }
            bucketFull = true;
            //Debug.Log("not enough kerosine");
            Debug.Log(amountNeeded);

            PlayerMoney.instance.playerMoney += buyPrice;

            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);

            Debug.Log(PlayerMoney.instance.playerMoney + " after");

            PlayerMoney.instance.UpdatePlayerMoney();

            Debug.Log("selling");

        }
        return amountNeeded;
    }
}
