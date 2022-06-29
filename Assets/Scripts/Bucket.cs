using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    public int amountNeeded = 10;
    public int buyPrice = 2;
    public int depletionValue = 1;

    private int playerKerosene;

    private GameObject activeCar;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activeCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        playerKerosene = activeCar.GetComponent<PlayerKerosene>().currentValue;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    public int KerosineDecrease(int depletionValue)
    {
        if (amountNeeded > 0 && playerKerosene >= 10)
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

    public int SellKerosine()
    {
        if(playerKerosene >= 10)
        {
            //PlayerMoney.instance.playerMoney += buyPrice;
            PlayerPrefs.GetInt("AmountOfMoney", PlayerMoney.instance.playerMoney += buyPrice);

            PlayerMoney.instance.UpdatePlayerMoney();

            Debug.Log("selling");
        }
        return buyPrice;
    }
}
