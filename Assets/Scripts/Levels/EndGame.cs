using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Win Game");
            Gamelogic gamelogic = FindObjectOfType<Gamelogic>();
            if (gamelogic != null)
                gamelogic.WinGame(gameObject);
        
        }
    }
}
