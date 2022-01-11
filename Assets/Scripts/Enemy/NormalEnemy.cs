using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    protected override void DamagePlayer()
    {
        if (PlayerInSight())
        {
            //Add some force
            Rigidbody2D rb = playerHealth.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.AddForce(new Vector2(force * transform.localScale.x, force), ForceMode2D.Impulse);
            //Take health
            playerHealth.TakeDamage(damage);
        }
    }
}
