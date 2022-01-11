using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamelogic : MonoBehaviour
{
    private void Awake()
    {
        var vcam = FindObjectOfType<CinemachineVirtualCamera>();
        PlayerFactory playerFactory = FindObjectOfType<PlayerFactory>();
        GameObject player = playerFactory.SpawnPlayer();
        vcam.LookAt = player.transform;
        vcam.Follow = player.transform;
    }

    public  GameObject playerDiedText;

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

    public  void HanldePlayerDied()
    {
        playerDiedText.gameObject.SetActive(true);  
        Time.timeScale = 0.0f;
    }
}
