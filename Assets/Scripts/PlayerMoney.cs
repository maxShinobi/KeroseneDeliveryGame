using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;

    public Text playerMoneyText;

    public int playerMoney;


    private void Awake()
    {
        instance = this;
        playerMoneyText.text = playerMoney + "$";
        playerMoneyText.text = "MONEY: " + playerMoney + "$";
        playerMoney = PlayerPrefs.GetInt("AmountOfMoney", playerMoney);
    }

    public void UpdatePlayerMoney()
    {
        playerMoneyText.text = playerMoney + "$";
        PlayerPrefs.SetInt("AmountOfMoney", playerMoney);
    }

    public void UpdatePlayerMoneyOnMainMenu()
    {
        playerMoneyText.text = "MONEY: " + playerMoney + "$";
        PlayerPrefs.SetInt("AmountOfMoney", playerMoney);
    }
}
