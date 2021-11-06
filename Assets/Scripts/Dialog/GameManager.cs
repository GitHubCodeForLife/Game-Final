using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GAME_STATE gameState = GAME_STATE.DIALOGUE_STARTING;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    void Awake()
    {
       PlayerPrefs.DeleteAll();
        int MyInt = PlayerPrefs.GetInt("MyGame");
        Debug.Log(MyInt);
        if (MyInt == 1)
            SceneManager.LoadScene("Menu");
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
}

public enum GAME_STATE
{
     CHARACTER_MOVING, 
     CHARACTER_ATTACKING, 
     DIALOGUE_STARTING,
     DIALOGUE_ENDING
}