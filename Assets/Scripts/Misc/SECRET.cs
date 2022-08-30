using UnityEngine;

public class SECRET : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerMoney.instance.playerMoney += 1000000;
            PlayerMoney.instance.UpdatePlayerMoney();
            Destroy(gameObject);
        }
    }
}
