using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    public string mainScene;

    [SerializeField] float rotationSpeed;

    [SerializeField] int currentCarIndex;

    [SerializeField] Button buyButton;
    [SerializeField] Button startButton;

    [SerializeField] GameObject[] carModels;
    [SerializeField] GameObject priceTag;

    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject carSelectionUI;
    [SerializeField] GameObject cars;

    [SerializeField] CarClass[] carClass;

    private void Start()
    {
        PlayerPrefs.GetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);

        foreach (CarClass car in carClass)
        {
            if (car.price == 0)
            {
                car.isUnlocked = true;
            } else
            {
                car.isUnlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false : true;
            }
        }

        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in carModels)
        {
            car.SetActive(false);
        }
        carModels[currentCarIndex].SetActive(true);
    }
    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        UpdateUI();
    }

    private void UpdateUI()
    {
        CarClass c = carClass[currentCarIndex];
        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            startButton.interactable = true;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            startButton.interactable = false;

            if (PlayerPrefs.GetInt("AmountOfMoney", PlayerMoney.instance.playerMoney) >= c.price)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

    public void UnlockCar()
    {
        CarClass c = carClass[currentCarIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        PlayerPrefs.SetInt("AmountOfMoney", PlayerMoney.instance.playerMoney - c.price);
        PlayerMoney.instance.UpdatePlayerMoneyOnMainMenu();
        c.isUnlocked = true;
    }

    public void NextCar()
    {
        //PlayerPrefs.GetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);

        carModels[currentCarIndex].SetActive(false);

        currentCarIndex++;

        if (currentCarIndex == carModels.Length)
        {
            currentCarIndex = 0;
        }
        carModels[currentCarIndex].SetActive(true);

        CarClass c = carClass[currentCarIndex];
        if (!c.isUnlocked)
        {
            startButton.interactable = false;
            return;
        }
        else
        {
            startButton.interactable = true;
        }

        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    public void PreviousCar()
    {
        //PlayerPrefs.GetInt("AmountOfMoney", PlayerMoney.instance.playerMoney);

        carModels[currentCarIndex].SetActive(false);

        currentCarIndex--;

        if (currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length - 1;
        }
        carModels[currentCarIndex].SetActive(true);

        CarClass c = carClass[currentCarIndex];
        if (!c.isUnlocked)
        {
            startButton.interactable = false;
            return;
        }
        else
        {
            startButton.interactable = true;
        }

        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    public void StartGame()
    {
        CarClass c = carClass[currentCarIndex];
        if (!c.isUnlocked)
        {
            startButton.interactable = false;
        }
        else
        {
            startButton.interactable = true;
            SceneManager.LoadScene(mainScene);
        }
    }

    public void BackButton()
    {
        mainMenuUI.SetActive(true);
        carSelectionUI.SetActive(false);
        cars.SetActive(false);
    }
}
