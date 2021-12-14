using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamelogic : MonoBehaviour
{
    public  Text playerDiedText;

    private void OnEnable()
    {
        PlayerHealth.playerDied += HanldePlayerDied;
    }

    private void OnDisable()
    {
        PlayerHealth.playerDied -= HanldePlayerDied;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
