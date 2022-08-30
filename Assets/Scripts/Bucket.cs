using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    public int amountNeeded = 10;
    public int depletionValue = 1;

    int sellPrice = 20;

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

            if (amountNeeded <= 0)
            {
                gameObject.SetActive(false);

                bucketFull = true;

                PlayerMoney.instance.playerMoney += sellPrice;
                PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);
                PlayerMoney.instance.UpdatePlayerMoney();
            }
        }
        else
        {
            Debug.Log("not enough kerosine");
        }
        return amountNeeded;
    }
}
