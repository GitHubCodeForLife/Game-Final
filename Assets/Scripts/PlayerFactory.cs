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
        int index = 1;
        GameObject player =  Instantiate(players[index], startPosition.position, startPosition.rotation);
        return player;
    }
}
