using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
                Pause();
            else
                Resume();
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    void Resume()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loade Menu");
        string name = "Menu";
        if (LevelLoader.Instance != null)
        {
            Debug.Log("Loade Menu Inside");
            LevelLoader.Instance.LoadLevel(name);
        }
        else
            SceneManager.LoadScene("Menu"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
