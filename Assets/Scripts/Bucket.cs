using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    [SerializeField] private int amountNeeded;
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
            enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
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
                //PlayerKerosene.instance.sellKeroseneButton.SetActive(false);
            }
        } else
        {
            Debug.Log("not enough kerosine");
        }
        return amountNeeded;
    }

    public int SellKerosine()
    {
        if(PlayerKerosene.instance.currentValue >= 10)
        {
            PlayerMoney.instance.playerMoney += buyPrice;

            PlayerMoney.instance.UpdatePlayerMoney();
        }
        return buyPrice;
    }
}
