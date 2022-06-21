using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [SerializeField] int lostKeroseneValue;

    [SerializeField] private float rotateSpeed;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = Player.transform.rotation;
    }

    private void Update()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Player.transform.position = new Vector3(originalPosition.x, 10, originalPosition.z);
        
        Player.transform.rotation = originalRotation;

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
