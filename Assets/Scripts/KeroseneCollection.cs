using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroseneCollection : MonoBehaviour
{
    [SerializeField] Canvas keroseneCollectionCanvas;

    int kerosenePrice = 1;

    bool buyButtonPressed;
    bool playerTankIsFull;

    private void Awake()
    {
        keroseneCollectionCanvas.enabled = false;
        playerTankIsFull = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keroseneCollectionCanvas.enabled = true;
        }

        if (PlayerKerosene.instance.currentValue < PlayerKerosene.instance.maximumValue)
        {
            playerTankIsFull = false;
        }

        if (buyButtonPressed && !playerTankIsFull)
        {
            PlayerKerosene.instance.FillTheKeroseneBar(1);
            PlayerMoney.instance.UpdatePlayerMoney();
            BuyKerosine(kerosenePrice);

            if (PlayerKerosene.instance.currentValue == PlayerKerosene.instance.maximumValue)
            {
                playerTankIsFull = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        keroseneCollectionCanvas.enabled = false;
    }

    public void CanBuyKerosene(bool buying)
    {
        if (buying)
        {
            buyButtonPressed = true;
        }
        else
        {
            buyButtonPressed = false;
        }
    }

    private int BuyKerosine(int buyValue)
    {
        if (PlayerMoney.instance.playerMoney >= 1 && PlayerKerosene.instance.currentValue <= PlayerKerosene.instance.maximumValue)
        {
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney -= buyValue);

            Debug.Log("buying kerosene");

            if (PlayerKerosene.instance.currentValue == PlayerKerosene.instance.maximumValue)
            {
                Debug.Log("Tank is full");
            }
        }
        else
        {
            Debug.Log("not enough money");
        }
        return PlayerMoney.instance.playerMoney;
    }
}
