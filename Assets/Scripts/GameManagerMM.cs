using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMM : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject carSelectionUI;
    [SerializeField] GameObject cars;

    public string mainMenu;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        if(carSelectionUI.activeInHierarchy || cars.activeInHierarchy || !mainMenuUI.activeInHierarchy)
        {
            mainMenuUI.SetActive(true);
            carSelectionUI.SetActive(false);
            cars.SetActive(false);
        }
    }

    public void Play()
    {
        mainMenuUI.SetActive(false);
        carSelectionUI.SetActive(true);
        cars.SetActive(true);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ClearPP()
    {
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(mainMenu);
        }
    }
}
