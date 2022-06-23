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

    private void Awake()
    {
        keroseneCollectionCanvas.enabled = false;
        enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        enabled = true;
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
        enabled = false;
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
            PlayerMoney.instance.playerMoney -= buyValue;

            if (PlayerKerosene.instance.currentValue == PlayerKerosene.instance.maximumValue)
            {
                playerTankIsFull = true;
                canBuySomeKerosine = false;
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
}
