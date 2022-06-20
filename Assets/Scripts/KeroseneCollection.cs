using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            SellKerosine(kerosenePrice);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enabled = false;
        keroseneCollectionCanvas.enabled = false;
    }

    public void BuyKerosene(bool buying)
    {
        if(buying)
        {
            buyButtonPressed = true;
        } else
        {
            buyButtonPressed = false;
        }
    }

    private int SellKerosine(int sellValue)
    {
        if (PlayerKerosene.instance.playerMoney >= 1 && PlayerKerosene.instance.currentValue <= 199)
        {
            PlayerKerosene.instance.playerMoney -= sellValue;
        }
        else
        {
            //play audio
        }
        return PlayerKerosene.instance.playerMoney;
    }
}
