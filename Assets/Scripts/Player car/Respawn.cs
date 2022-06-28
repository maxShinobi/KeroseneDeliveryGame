using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] int lostKeroseneValue;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    bool grounded;

    private void Start()
    {
        Player.transform.rotation = originalRotation;
        grounded = true;
    }

    private void Update()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        originalRotation = new Quaternion(Player.transform.rotation.w, Player.transform.rotation.y, Player.transform.rotation.x, Player.transform.rotation.z);
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Player.transform.position = new Vector3(originalPosition.x, 1, originalPosition.z);

            originalRotation = Player.transform.rotation;

        PlayerLosesSomeKerosene();
    }

    private void PlayerLosesSomeKerosene()
    {
        if(PlayerKerosene.instance.currentValue >= 20)
        {
            PlayerKerosene.instance.DepleteTheKeroseneBar(lostKeroseneValue);
        }
    }
}
