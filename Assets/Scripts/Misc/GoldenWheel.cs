using UnityEngine;

public class GoldenWheel : MonoBehaviour
{
    public static GoldenWheel instance;

    public bool coinDeactivated = false;

    private void Awake()
    {
        instance = this;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMoney.instance.playerMoney += 2;
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);
            PlayerMoney.instance.UpdatePlayerMoney();
            gameObject.SetActive(false);
            coinDeactivated = true;
        }
    }
}
