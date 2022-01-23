using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamelogic : MonoBehaviour
{
    private Vector2 savePoint;
    public  GameObject playerDiedText;
    public GameObject winGameUI;
    public Transform startPosition;
    //Mission kill Enemies
    public GameMission gameMission;

    private void Awake()
    {
        savePoint = startPosition.position;
        SpawnPlayer(savePoint);
    }

    private static void SpawnPlayer(Vector2 pos)
    {
        Time.timeScale = 1.0f;
        var vcam = FindObjectOfType<CinemachineVirtualCamera>();
        PlayerFactory playerFactory = FindObjectOfType<PlayerFactory>();
        GameObject player = playerFactory.SpawnPlayer(pos);
        vcam.Follow = player.transform;
    }


    private void OnEnable()
    {
        PlayerHealth.playerDied += HanldePlayerDied;
    }

    private void OnDisable()
    {
        PlayerHealth.playerDied -= HanldePlayerDied;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }

    public void HanldePlayerDied()
    {
        playerDiedText.gameObject.SetActive(true);  
    }
    public void SetSavePoint(Vector2 pos)
    {
        this.savePoint = pos;
        //Debug.Log("Game Logic : " + pos);
    }

    public void WinGame(GameObject game)
    {
        if (gameMission == null)
        {
            winGameUI.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        //If level Complete
        else if (gameMission.IsCompleteMission())
        {
            //Destroy(game, 1f);
            winGameUI.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void PlayAgain()
    {
        winGameUI.gameObject.SetActive(false);
        playerDiedText.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Vector2 pos = new Vector2(0, 1.5f);
        SpawnPlayer(savePoint+pos);
    }
    public void PlayGameAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void KillNewEnemy(GameObject enemy)
    {
        if (gameMission != null)
            gameMission.KillNewEnemy(enemy);
        Debug.Log("Kill new Enemy: " + enemy.name);
    }
}
