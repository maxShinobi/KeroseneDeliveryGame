using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] int lostKeroseneValue;

    Vector3 originalPosition;

    float originalRotationX;
    float originalRotationY;
    float originalRotationZ;

    bool grounded;

    private void Start()
    {
        originalRotationX = Player.transform.rotation.x;
        originalRotationZ = Player.transform.rotation.z;

        grounded = true;
    }

    private void Update()
    {
        originalPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        Player.transform.position = new Vector3(originalPosition.x, 2, originalPosition.z);

        Player.transform.rotation = Quaternion.Euler(originalRotationX, originalRotationY, originalRotationZ);

        PlayerLosesSomeKerosene();
    }

    private void PlayerLosesSomeKerosene()
    {
        if(PlayerKerosene.instance.currentValue >= 20)
        {
            PlayerKerosene.instance.DepleteTheKeroseneBar(lostKeroseneValue);

            if(PlayerKerosene.instance.currentValue < 20)
            {
                PlayerKerosene.instance.currentValue = 0;
            }
        }
    }
}
