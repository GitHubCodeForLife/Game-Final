using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GAME_STATE gameState = GAME_STATE.DIALOGUE_STARTING;
   private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        bool isPassIntro = GameStorageManager.gameInfo.isPassIntro;
        if (isPassIntro == true)
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    private void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameState);
        if(GameManager.gameState==GAME_STATE.DIALOGUE_STARTING)
        {
            playerAttack.enabled = false;
            playerMovement.enabled = false;
        }else if (gameState == GAME_STATE.DIALOGUE_ENDING)
        {
            playerAttack.enabled = true;
            playerMovement.enabled = true;
        }
        else if (gameState == GAME_STATE.CHARACTER_MOVING)
        {
            playerAttack.enabled = false;
            playerMovement.enabled = true;
        }
        else if (gameState == GAME_STATE.CHARACTER_ATTACKING)
        {
            playerAttack.enabled = true;
            playerMovement.enabled = false;
        }
    }
    private void OnDestroy()
    {
        GameStorageManager.gameInfo.isPassIntro = true;
        GameStorageManager.SaveGameInfo();
    }
}

public enum GAME_STATE
{
     CHARACTER_MOVING, 
     CHARACTER_ATTACKING, 
     DIALOGUE_STARTING,
     DIALOGUE_ENDING
}