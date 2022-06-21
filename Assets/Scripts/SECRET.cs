using UnityEngine;

public class SECRET : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerKerosene.instance.playerMoney += 1000000;
            PlayerKerosene.instance.UpdatePlayerMoney();
            Destroy(gameObject);
        }
    }
}
