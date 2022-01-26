using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //Rigidbody2D rd = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerHealth != null )
            {
                //bool IsBelown = transform.position.y > collision.transform.position.y;
                //if (IsBelown)
                //    rd.AddForce(new Vector2(collision.transform.localScale.x * -4, -4), ForceMode2D.Impulse);
                //else
                //    rd.AddForce(new Vector2(collision.transform.localScale.x * -4, 4), ForceMode2D.Impulse);
                playerHealth.KillPlayer();
                //Destroy(gameObject);
            }
        }
    } 
  
}
