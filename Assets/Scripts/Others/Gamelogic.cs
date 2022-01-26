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
    public int currentLevel;

    private void Start()
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
        if (gameMission == null || gameMission.IsCompleteMission())
        {
            winGameUI.gameObject.SetActive(true);
            int stars;
            if (game != null)
                stars = gameMission.CountStar();
            else
                stars = 3;
          
            currentLevel =  GetCurrentLevel();
            LevelInfo levelInfo = GameStorageManager.gameInfo.levels[currentLevel];
            levelInfo.stars = stars;
            bool IsPassLevel = stars >= 0;
            int nextLevel = currentLevel+1;

            if (IsPassLevel == true)
            {
                levelInfo.state = LEVEL_STATE.PASSED;
                if (GameStorageManager.gameInfo.levels.Count > currentLevel + 1 &&
                    GameStorageManager.gameInfo.levels[nextLevel].state == LEVEL_STATE.LOCK)
                    GameStorageManager.gameInfo.levels[nextLevel].state = LEVEL_STATE.OPENING;
                //Debug.Log("Current Level: " + levelInfo.name + "---" + levelInfo.stars + "--" + levelInfo.state);
                //LevelInfo nextLevelInfo = GameStorageManager.gameInfo.levels[nextLevel];
                //Debug.Log("Next level: " + nextLevelInfo.name + "--" + nextLevelInfo.stars + "---" + nextLevelInfo.state);
            }
         
            GameStorageManager.SaveGameInfo();
            Time.timeScale = 0.0f;
            
        }
    }

    private int GetCurrentLevel()
    {
        List<LevelInfo> levels = GameStorageManager.gameInfo.levels;
        Scene scene = SceneManager.GetActiveScene();
       // Debug.Log("Current Level: " + scene);
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].name.Equals(scene.name)) return i;
        }
        return 0;
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
