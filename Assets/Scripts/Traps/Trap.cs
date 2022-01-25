using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();
            if (playerHealth != null && rd != null)
            {
                bool IsBelown = transform.position.y > collision.transform.position.y;
                if (IsBelown)
                    rd.AddForce(new Vector2(collision.transform.localScale.x * -4, -4), ForceMode2D.Impulse);
                else
                    rd.AddForce(new Vector2(collision.transform.localScale.x * -4, 4), ForceMode2D.Impulse);
                playerHealth.TakeDamage(damage);
                //Destroy(gameObject);
            }
        }
    }
}
