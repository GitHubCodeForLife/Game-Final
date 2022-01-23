using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    private int damage  = 1;
    public float timeExist = 10f;
    private void Update()
    {
        timeExist -= Time.deltaTime;
        if (timeExist <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
