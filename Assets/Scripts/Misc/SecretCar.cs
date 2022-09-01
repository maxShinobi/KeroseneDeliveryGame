using UnityEngine;

public class SecretCar : MonoBehaviour
{
    public static SecretCar instance;

    public bool mordFustangUnlocked;

    public void Awake()
    {
        instance = this;
        mordFustangUnlocked = false;
    }

    public void OnTriggerEnter(Collider mordFustang)
    {
        if (mordFustang.gameObject.tag == "Player")
        {
            mordFustangUnlocked = true;
            Destroy(gameObject);
        }
    }
}
