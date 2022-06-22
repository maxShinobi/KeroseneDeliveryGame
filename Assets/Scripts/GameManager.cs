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
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject keroseneUI;

    private void Awake()
    {
        instance = this;
    }

    public void PauseGame(bool paused)
    {
        if (paused)
        {
            pauseScreen.SetActive(true);
            DisableThings();
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame(bool unpaused)
    {
        if(unpaused)
        {
            pauseScreen.SetActive(false);
            EnableThings();
            Time.timeScale = 1f;
        }
    }

    public void Settings(bool setting)
    {
        if(setting)
        {

        }
    }

    public void ExitGame(bool exiting)
    {
        if(exiting)
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    private void DisableThings()
    {
        playerUI.SetActive(false);
        keroseneUI.SetActive(false);
    }

    private void EnableThings()
    {
        playerUI.SetActive(true);
        keroseneUI.SetActive(true);
    }
}
