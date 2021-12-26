using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    PlayerResource playerResource;

    private Animator animator;

    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    public void ChangeCoin(int amount)
    {
        playerResource.ChangeCoin(amount);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerResource = FindObjectOfType<PlayerResource>();
    }
    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        animator.SetTrigger("Hurt");
        playerResource.ChangeLife(-1);
        if (playerResource.IsDied())
            Died();
    }

    private void Died()
    {
        animator.SetBool("IsDie", true);
        if (playerDied != null)
            playerDied();
       // Destroy(gameObject, 2f);    
    }
}
