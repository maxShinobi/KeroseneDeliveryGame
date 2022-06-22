using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] int currentCarIndex;

    [SerializeField] GameObject[] carModels;

    private void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);

            carModels[currentCarIndex].SetActive(true);
        }
    }
    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    public void NextCar()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex++;

        if (currentCarIndex == carModels.Length)
        {
            currentCarIndex = 0;
        }
        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    public void PreviousCar()
    {
        carModels[currentCarIndex].SetActive(false);

        currentCarIndex--;

        if (currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length -1;
        }
        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }
}
