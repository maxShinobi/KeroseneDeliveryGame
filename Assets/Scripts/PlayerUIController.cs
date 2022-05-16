using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public static PlayerUIController instance;

    public Text playerMoneyText;

    private void Awake()
    {
        instance = this;
    }
}
