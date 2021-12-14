using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int coin = 10;
    public Text textCoin;
    public int lives = 3;
    public Text textLife;

    private Animator animator;

    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    public void ChangeCoin(int amount)
    {
        coin += amount;
        if (textCoin) textCoin.text = coin.ToString();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        // = gameObject.GetComponent<Text>();
    }
    public void TakeDamage(int damage)
    {
        //Debug.Log(damage);
        animator.SetTrigger("Hurt");
        lives--;
        if (lives == 0)
            Died();
        textLife.text = lives.ToString();
    }

    private void Died()
    {
        animator.SetBool("IsDie", true);
        if (playerDied != null)
            playerDied();
       // Destroy(gameObject, 2f);    
    }
}
