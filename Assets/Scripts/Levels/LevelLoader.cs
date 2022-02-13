using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    private float timeLoading = 0.9f;
    public static LevelLoader Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadLevel(string scenceName)
    {
        StartCoroutine(Asynchronously(scenceName));
    }

    IEnumerator Asynchronously(string scenceName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenceName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / timeLoading);
            slider.value = progress;
            yield return null; //Wait a frame
        }
    }

}
