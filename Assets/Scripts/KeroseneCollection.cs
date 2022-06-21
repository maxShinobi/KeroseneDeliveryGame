using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeroseneCollection : MonoBehaviour
{
    [SerializeField] Canvas keroseneCollectionCanvas;

    int kerosenePrice = 1;

    bool buyButtonPressed;

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

        if (buyButtonPressed)
        {
            PlayerKerosene.instance.FillTheKeroseneBar(1);
            PlayerKerosene.instance.UpdatePlayerMoney();
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
        if (PlayerKerosene.instance.playerMoney >= 1 && PlayerKerosene.instance.currentValue <= PlayerKerosene.instance.maximumValue)
        {
            PlayerKerosene.instance.playerMoney -= buyValue;
        }
        else
        {
            Debug.Log("not enough money or tank is full");
        }
        return PlayerKerosene.instance.playerMoney;
    }
}
