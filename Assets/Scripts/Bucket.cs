using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    [SerializeField] GameObject pressEtoSell;

    private int amountNeeded = 10;
    private int buyPrice = 2;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressEtoSell.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressEtoSell.SetActive(false);
    }

    public int KerosineDecrease(int depletionValue)
    {
        if(amountNeeded > 0 && PlayerKerosene.instance.currentValue >= 10)
        {
            amountNeeded -= depletionValue;

            if (amountNeeded == 0)
            {
                gameObject.SetActive(false);
            }
        } else
        {
            Debug.Log("not enough kerosine");
        }
        return amountNeeded;
    }

    public int BuyKerosine()
    {
        PlayerKerosene.instance.playerMoney += buyPrice;

        return buyPrice;
    }
}
