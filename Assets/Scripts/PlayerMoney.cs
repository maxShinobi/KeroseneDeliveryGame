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
    }

    private void Start()
    {
        playerMoney = PlayerPrefs.GetInt("AmountOfMoney", 3000);

        playerMoneyText.text = playerMoney + "$";
        playerMoneyText.text = "MONEY: " + playerMoney + "$";
    }

    public void UpdatePlayerMoney()
    {
        playerMoney = PlayerPrefs.GetInt("AmountOfMoney", playerMoney);

        playerMoneyText.text = playerMoney + "$";
    }

    public void UpdatePlayerMoneyOnMainMenu()
    {
        playerMoney = PlayerPrefs.GetInt("AmountOfMoney", playerMoney);

        playerMoneyText.text = "MONEY: " + playerMoney + "$";
    }
}
