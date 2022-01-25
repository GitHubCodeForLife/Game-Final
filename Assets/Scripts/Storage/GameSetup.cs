using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public int gold;
    public Text coinText;

    // Start is called before the first frame update
    private void Awake()
    {
        InitialGold();
        ReadGold();
    }

    private void ReadGold()
    {
        gold = GameStorageManager.gameInfo.playerInfo.gold;
        coinText.text = gold.ToString();
    }

    private void InitialGold()
    {
        if(GameStorageManager.gameInfo.playerInfo==null)
        {
            PlayerInfo playerInfo = new PlayerInfo();
            playerInfo.gold = gold;
            GameStorageManager.gameInfo.playerInfo = playerInfo;
            GameStorageManager.SaveGameInfo();
        }
    }

 
}
