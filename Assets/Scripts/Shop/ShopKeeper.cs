using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public GameObject msgBox;
    public Text msg;
    public static ShopKeeper instance;
    public Text money;
    private void Awake()
    {
        instance = this;
    }

    public bool Purchase(int gold)
    {
        if (gold > GameStorageManager.gameInfo.playerInfo.gold)
        {
            msgBox.SetActive(true);
            msg.text = "You don't have enough money";
            msg.color = Color.red;
            StartCoroutine(WaitPlayerDie(2f));
            return false;
        } 
        GameStorageManager.gameInfo.playerInfo.gold -= gold;
        GameStorageManager.SaveGameInfo();
        msgBox.SetActive(true);
        msg.text = "Purchase success";
        msg.color = Color.green;
        StartCoroutine(WaitPlayerDie(2f));
        //update money
        money.text = GameStorageManager.gameInfo.playerInfo.gold.ToString();
        return true;
    }

    private IEnumerator WaitPlayerDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        msgBox.SetActive(false);
    }

}
