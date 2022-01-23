using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject effectPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            PlayerAttack playerAttack = collision.gameObject.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                playerAttack.PowerDamage();
            }

            if (effectPrefab != null)
            {
                GameObject collectedObject = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(collectedObject, 1.5f);
            }
            Destroy(gameObject);
        }
    }
}
