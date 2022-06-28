using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public static Bucket instance;

    [SerializeField] private int amountNeeded;

    private int buyPrice = 2;
    private int playerKerosene;

    private GameObject activeCar;

    private void Awake()
    {
        instance = this;
        enabled = false;
    }

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activeCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        playerKerosene = activeCar.GetComponent<PlayerKerosene>().currentValue;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == activeCar)
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
        if(amountNeeded > 0 && playerKerosene >= 10)
        {
            Debug.Log("can sell");
            amountNeeded -= depletionValue;

            if (amountNeeded == 0)
            {
                gameObject.SetActive(false);
                Debug.Log("disabled");
            }
        } else
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
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney += buyPrice);

            PlayerMoney.instance.UpdatePlayerMoney();
        }
        return buyPrice;
    }
}
