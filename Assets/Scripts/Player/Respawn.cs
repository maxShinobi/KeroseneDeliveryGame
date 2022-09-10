using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] int lostKeroseneValue;

    Vector3 originalPosition;
    Quaternion originalRotation;

    float originalPositionX;
    float originalPositionY;
    float originalPositionZ;

    float originalRotationW;
    float originalRotationX;
    float originalRotationY;
    float originalRotationZ;

    GameObject activePlayerCar;

    private void Start()
    {
        StartGameCarSelection.instance.CheckActiveCar();
        activePlayerCar = StartGameCarSelection.instance.cars[StartGameCarSelection.instance.currentCarIndex];
        //currentPlayerKeroseneValue = PlayerPrefs.GetInt("AmountOfKerosene", PlayerKerosene.instance.currentValue);

        originalPositionX = activePlayerCar.transform.position.x;
        originalPositionY = activePlayerCar.transform.position.y;
        originalPositionZ = activePlayerCar.transform.position.z;

        originalRotationW = activePlayerCar.transform.rotation.w;
        originalRotationX = activePlayerCar.transform.rotation.x;
        originalRotationY = activePlayerCar.transform.rotation.y;
        originalRotationZ = activePlayerCar.transform.rotation.z;
    }

    private void Update()
    {
        originalPosition = new Vector3(originalPositionX, originalPositionY, originalPositionZ);
        originalRotation = new Quaternion(originalRotationW, originalRotationX, originalRotationY, originalRotationZ);
    }

    public void RespawnCar()
    {
        originalPosition = new Vector3(activePlayerCar.transform.position.x, activePlayerCar.transform.position.y, activePlayerCar.transform.position.z);
        activePlayerCar.transform.position = new Vector3(originalPosition.x, 4, originalPosition.z);

        originalRotation = Quaternion.Euler(activePlayerCar.transform.rotation.x, activePlayerCar.transform.rotation.y, activePlayerCar.transform.rotation.z);
        activePlayerCar.transform.rotation = Quaternion.Euler(0f, activePlayerCar.transform.eulerAngles.y, 0f);

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
