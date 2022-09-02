using UnityEngine;

public class SECRET : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerMoney.instance.playerMoney += 1000000;
            PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);
            PlayerMoney.instance.UpdatePlayerMoney();
            Destroy(gameObject);
        }
    }
}
