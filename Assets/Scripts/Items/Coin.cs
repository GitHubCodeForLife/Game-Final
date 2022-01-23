using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public GameObject effectPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.ChangeCoin(value);
            if (effectPrefab != null)
            {
                GameObject collectedObject = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(collectedObject, 1.5f);
            }
            Destroy(gameObject);
        }
    }
}
