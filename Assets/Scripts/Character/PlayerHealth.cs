using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int life = 10;
    int coin = 100;
    private Animator animator;

    public delegate void PlayerDied();
    public static event PlayerDied playerDied;

    public float deathlessTimer = 2f;
    private float currentDeathlesstTimer = 0;
    private void Awake()
    {
        

        currentDeathlesstTimer = 0;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        currentDeathlesstTimer = currentDeathlesstTimer < 0 ? currentDeathlesstTimer : currentDeathlesstTimer - Time.deltaTime;
        HUDPlayer.instance.SetCoinText(coin);
        HUDPlayer.instance.SetLifeText(life);
    }
    public void ChangeCoin(int amount)
    {
        coin += amount;
        HUDPlayer.instance.SetCoinText(coin);
    }
    public void TakeDamage(int damage)
    {
        if (currentDeathlesstTimer > 0) return;
        currentDeathlesstTimer = deathlessTimer;

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
        //if (playerDied != null)
          //  playerDied();
       // Destroy(gameObject, 2f);    
    }
}
