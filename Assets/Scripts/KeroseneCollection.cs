using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroseneCollection : MonoBehaviour
{
    [SerializeField] Canvas keroseneCollectionCanvas;

    int kerosenePrice = 1;

    bool buyButtonPressed;
    bool playerTankIsFull;
    bool canBuySomeKerosine;

    private GameObject activeCar;

    private int currentPlayerKeroseneValue;
    private int maxmimumPlayerKeroseneValue;

    private void Awake()
    {
        keroseneCollectionCanvas.enabled = false;
    }

    private void Start()
    {
        //StartGameCarSelection.instance.CheckActiveCar();
        //activeCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        currentPlayerKeroseneValue = PlayerPrefs.GetInt("AmountOfKerosene", PlayerKerosene.instance.currentValue);
        //ActivePlayerCurrentKeroseneValue();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keroseneCollectionCanvas.enabled = true;
        }

        if (buyButtonPressed && !playerTankIsFull)
        {
            PlayerKerosene.instance.FillTheKeroseneBar(1);
            PlayerMoney.instance.UpdatePlayerMoney();
            BuyKerosine(kerosenePrice);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        keroseneCollectionCanvas.enabled = false;
    }

    public void CanBuyKerosene(bool buying)
    {
        if(buying)
        {
            buyButtonPressed = true;
        } else
        {
            buyButtonPressed = false;
        }
    }

    private int BuyKerosine(int buyValue)
    {
        if (PlayerMoney.instance.playerMoney >= 1 && PlayerKerosene.instance.currentValue <= PlayerKerosene.instance.maximumValue)
        {
            canBuySomeKerosine = true;

            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney -= buyValue);

            if (PlayerKerosene.instance.currentValue == PlayerKerosene.instance.maximumValue)
            {
                playerTankIsFull = true;
                canBuySomeKerosine = false;
                PlayerPrefs.GetInt("AmountOfKerosene", PlayerKerosene.instance.currentValue);
                Debug.Log("Tank is full");
            } else
            {
                playerTankIsFull = false;
                canBuySomeKerosine = true;
            }
        }
        else
        {
            Debug.Log("not enough money");
        }
        return PlayerMoney.instance.playerMoney;
    }

    private void ActivePlayerCurrentKeroseneValue()
    {
        activeCar.GetComponent<PlayerKerosene>().SetCurrentState();
    }
}
