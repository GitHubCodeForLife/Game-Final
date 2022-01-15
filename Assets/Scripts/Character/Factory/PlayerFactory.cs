using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public List<GameObject> players;
    public Transform startPosition;
    public GameObject SpawnPlayer()
    {
        // Read type of player Form local Storage
        //PlayerPrefs.SetInt("CurrentPlayer", currentPlayer);
        string name = GameStorageManager.GetSelectedPlayer();
        GameObject playerPrefab = GetSelectedPlayer(name);
        GameObject player =  Instantiate(playerPrefab, startPosition.position, startPosition.rotation);
        return player;
    }
    private GameObject GetSelectedPlayer(string name)
    {
        foreach (var player in players) {
            if (player.name == "Warrior") return player;
        }
        return null;
    }
}
