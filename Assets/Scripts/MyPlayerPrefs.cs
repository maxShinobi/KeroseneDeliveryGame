using System.Collections;
using UnityEngine;

public class MyPlayerPrefs : PlayerPrefs
{
    public static MyPlayerPrefs instance;

    public MyPlayerPrefs()
    {
        if (instance == null)
        {
            instance = new MyPlayerPrefs();
        }
    }
    public int GetPlayerMoney(int playerMoney)
    {
        return PlayerPrefs.GetInt("AmountOfMoney", playerMoney);
    }
}