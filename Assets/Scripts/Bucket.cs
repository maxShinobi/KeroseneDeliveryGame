using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    [SerializeField] GameObject pressEtoSell;

    [SerializeField] Button sellKeroseneButton;

    private int amountNeeded = 10;
    private int buyPrice = 2;

    private void Awake()
    {
        instance = this;
        enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sellKeroseneButton.enabled = true;
            enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sellKeroseneButton.enabled = false;
        enabled = false;
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
        if(PlayerKerosene.instance.currentValue >= 10)
        {
            PlayerKerosene.instance.playerMoney += buyPrice;

            PlayerKerosene.instance.UpdatePlayerMoney();
        } else
        {
            Debug.Log("No kerosene to sell");
        }
        return buyPrice;
    }
}
