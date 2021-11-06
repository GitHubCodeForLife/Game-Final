using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScence(2);
        SceneManager.LoadScene("SelectLevel");
        //SceneManager.LoadScence(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
