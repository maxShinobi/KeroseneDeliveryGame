using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] int lostKeroseneValue;

    Vector3 originalPosition;

    float originalRotationX;
    float originalRotationY;
    float originalRotationZ;

    GameObject activePlayerCar;

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activePlayerCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        //currentPlayerKeroseneValue = PlayerPrefs.GetInt("AmountOfKerosene", PlayerKerosene.instance.currentValue);

        originalRotationX = activePlayerCar.transform.rotation.x;
        originalRotationZ = activePlayerCar.transform.rotation.z;
    }

    private void Update()
    {
        originalPosition = new Vector3(activePlayerCar.transform.position.x, activePlayerCar.transform.position.y, activePlayerCar.transform.position.z);
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(activePlayerCar.transform.position.x, activePlayerCar.transform.position.y, activePlayerCar.transform.position.z);
        activePlayerCar.transform.position = new Vector3(originalPosition.x, 2, originalPosition.z);

        activePlayerCar.transform.rotation = Quaternion.Euler(originalRotationX, originalRotationY, originalRotationZ);

        PlayerLosesSomeKerosene();
    }

    private void PlayerLosesSomeKerosene()
    {
        if(PlayerKerosene.instance.currentValue >= lostKeroseneValue)
        {
            PlayerKerosene.instance.DepleteTheKeroseneBar(lostKeroseneValue);
        }

        if (PlayerKerosene.instance.currentValue < lostKeroseneValue)
        {
            PlayerKerosene.instance.currentValue = 0;

            PlayerKerosene.instance.DepleteTheKeroseneBar(lostKeroseneValue);
        }
    }
}
