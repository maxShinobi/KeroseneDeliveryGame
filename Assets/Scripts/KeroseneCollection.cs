using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeroseneCollection : MonoBehaviour
{
    [SerializeField] Canvas keroseneCollectionCanvas;

    int kerosenePrice = 1;

    private void Awake()
    {
        keroseneCollectionCanvas.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            keroseneCollectionCanvas.enabled = true;

            if (Input.GetKey(KeyCode.E))
            {
                PlayerKerosene.instance.FillTheKeroseneBar(1);
                PlayerKerosene.instance.UpdatePlayerMoney();
                SellKerosine(kerosenePrice);

                if(PlayerKerosene.instance.currentValue == 100)
                {
                    //play audio
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        keroseneCollectionCanvas.enabled = false;
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
