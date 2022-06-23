using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCarSelection : MonoBehaviour
{
    public static StartGameCarSelection instance;

    public int currentCarIndex;

    public GameObject[] cars;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in cars)
        {
            car.SetActive(false);

            cars[currentCarIndex].SetActive(true);
        }
    }
}
