using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string mainMenu;

    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject keroseneUI;
    [SerializeField] GameObject[] cars;

    [SerializeField] int activeCarIndex;

    
    GameObject activePlayerCanvas;

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1f;
    }

    private void Start()
    {
        activeCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);

        foreach (GameObject car in cars)
        {
            if(car.activeInHierarchy)
            {
                activePlayerCanvas = GameObject.Find("PlayerUI");
            }
        }
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        DisableThings();
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        EnableThings();
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(mainMenu);
    }

    private void DisableThings()
    {
        activePlayerCanvas.SetActive(false);
        keroseneUI.SetActive(false);
        pauseButton.SetActive(false);
    }

    private void EnableThings()
    {
        activePlayerCanvas.SetActive(true);
        keroseneUI.SetActive(true);
        pauseButton.SetActive(true);
    }
}
