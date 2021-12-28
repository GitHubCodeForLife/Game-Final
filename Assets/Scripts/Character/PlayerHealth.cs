using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int life = 3;
    int coin = 100;
    private Animator animator;

    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    public void ChangeCoin(int amount)
    {
        coin += amount;
        HUDPlayer.instance.SetCoinText(coin);
    }
    private void Update()
    {
        HUDPlayer.instance.SetCoinText(coin);
        HUDPlayer.instance.SetLifeText(life);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
      
    }
    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        life--;
        animator.SetTrigger("Hurt");
        HUDPlayer.instance.SetLifeText(life);
        if (life<=0)
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
