using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeroseneCollection : MonoBehaviour
{
    [SerializeField] GameObject pressEtoBuy;

    int kerosenePrice = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressEtoBuy.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                PlayerKerosene.instance.FillTheKeroseneBar(1);
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
            pressEtoBuy.SetActive(false);
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
