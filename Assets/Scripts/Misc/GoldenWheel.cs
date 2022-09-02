using UnityEngine;

public class GoldenWheel : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMoney.instance.playerMoney += 2;
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);
            PlayerMoney.instance.UpdatePlayerMoney();
            Destroy(gameObject);
        }
    }
}
