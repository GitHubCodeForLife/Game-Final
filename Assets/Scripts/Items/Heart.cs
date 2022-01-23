using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject effectPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.ChangeHealth(1);
            if (effectPrefab != null)
            {
                GameObject collectedObject = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(collectedObject, 1.5f);
            }
            Destroy(gameObject);
        }
    }
}
