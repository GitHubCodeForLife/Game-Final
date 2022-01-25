using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CardLevel : MonoBehaviour
{
    public List<LevelInfo> levelsInput;
    public GameObject[] listLevels;
    public GridLayoutGroup gridLayout;

    private void Awake()
    {
        InitialLevels();
        ReadLevels();
    }

    private void ReadLevels()
    {
        levelsInput = GameStorageManager.gameInfo.levels;   
    }

    private void InitialLevels()
    {
        if (GameStorageManager.gameInfo.levels != null) return;
        List<LevelInfo> levelsInfor = new List<LevelInfo>();
        foreach(LevelInfo level in levelsInput)
        {
            LevelInfo temp = new LevelInfo
            {
                name = level.name,
                stars = level.stars,
                state = level.state
            };
            levelsInfor.Add(temp);
        }
        GameStorageManager.gameInfo.levels = levelsInfor;
        GameStorageManager.SaveGameInfo();       
    }


    // Start is called before the first frame update
    void Start()
    {
        //Read From Cache / File
        for (int i = 0; i < levelsInput.Count; i++)
        {
            GameObject levelPrefab = GetLevelPrefabs(i);
            GameObject level = Instantiate(levelPrefab, gridLayout.transform.position, Quaternion.identity);
           
            LevelState levelState =  level.GetComponent<LevelState>();
            if (levelState != null)
            {
                string game = levelsInput[i].name;
                level.GetComponent<Button>().onClick.AddListener(() => LoadLevel(game));
                levelState.SetTextLevel(levelsInput[i].name);
            }
            level.transform.SetParent(gridLayout.transform);
        }

    }

    private GameObject GetLevelPrefabs(int i)
    {
        Debug.Log("Card Level " + levelsInput[i].state);
        GameObject levelPrefab;
        if (levelsInput[i].state == LEVEL_STATE.PASSED)
        {
            int stars = levelsInput[i].stars;
            levelPrefab = listLevels[stars];
        }
        else if (levelsInput[i].state == LEVEL_STATE.OPENING)
        {
            levelPrefab = listLevels[4];
        }
        else
        {
            levelPrefab = listLevels[0];
        }
       // Debug.Log("Card Level " + levelPrefab.name);
        return levelPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadLevel(string level)
    {
        Debug.Log(" Card Level - Load level " + level);
        SceneManager.LoadScene(level);
       // return null;
    }
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
