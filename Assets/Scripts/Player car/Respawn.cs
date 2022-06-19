using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject respawnButton;
    [SerializeField] GameObject Player;
    private Vector3 currentPosition;

    private void Update()
    {
        currentPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

/*        if (Input.GetKeyDown("r"))
        {
            Player.transform.position = new Vector3(currentPosition.x, 5, currentPosition.z);
            Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            respawnText.SetActive(false);
        }*/
    }

/*    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            respawnText.SetActive(true);
        }
    }*/

    public void RespawnCar()
    {
        currentPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Player.transform.position = new Vector3(currentPosition.x, 5, currentPosition.z);
        Player.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
