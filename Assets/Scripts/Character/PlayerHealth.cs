using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Shield 
  
    public GameObject shieldObject;

    private const float WaitTime = 2.0f;
    int maxLife = 10;
    int life = 3;
    int coin ;
    private Animator animator;

    public delegate void PlayerDied();

    internal void ChangeHealth(int v)
    {
        if (this.life <= 4)
            this.life += v;
        HUDPlayer.instance.SetLifeText(life);
    }

    public static event PlayerDied playerDied;

    public float deathlessTimer = 2f;
    private float currentDeathlessTimer = 0;

    private bool IsDie = false;

   // public bool IsTurnOnShield { get; private set; }

    private void Awake()
    {
        //Take form local storage
        //GameStorageManager.shopInfo.abilities
        IsDie = false;
        animator = GetComponent<Animator>();

        coin = GameStorageManager.gameInfo.playerInfo.gold;
    }

    internal void KillPlayer()
    {
        life = Mathf.Clamp(0, 0, maxLife);
        HUDPlayer.instance.SetLifeText(life);
        animator.SetTrigger("Hurt");
        if (life <= 0)
            Died();
    }

    private void Start()
    {
        currentDeathlessTimer = deathlessTimer;
        //IsTurnOnShield = false;
    }
    private void Update()
    {
        if (currentDeathlessTimer > 0 && IsDie==false )
        {
            TurnOnShield();
        }else
        {
            TurnOffShield();
        }
        currentDeathlessTimer = currentDeathlessTimer < 0 ? currentDeathlessTimer : currentDeathlessTimer - Time.deltaTime;
        HUDPlayer.instance.SetCoinText(coin);
        HUDPlayer.instance.SetLifeText(life);
    }

    internal void SetDeathLessTimer(int v)
    {
        currentDeathlessTimer = v;
    }

    private void TurnOffShield()
    {
        if (shieldObject != null)
            shieldObject.SetActive(false);
    }

    private void TurnOnShield()
    {
  
        if (shieldObject != null)
        {
            //Debug.Log("Turn on Shield");
            shieldObject.SetActive(true);
        }
    }

    public void ChangeCoin(int amount)
    {
        coin += amount;
        HUDPlayer.instance.SetCoinText(coin);
    }
    public void TakeDamage(int damage)
    {
        if (currentDeathlessTimer > 0) return;

        currentDeathlessTimer = deathlessTimer;
        //life--;
        life = Mathf.Clamp(life - 1, 0, maxLife);
        HUDPlayer.instance.SetLifeText(life);
        animator.SetTrigger("Hurt");
        if (life <= 0)
            Died();
        else
        {
            AudioManager.instance.PlayOneShot("Player_Hurt");
            if (CinemachineShake.Instance != null)
                CinemachineShake.Instance.ShakeCamera(5f, 0.3f);
        }
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitPlayerDie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (playerDied != null)
        {
            //  Debug.Log("Player Died");
            playerDied();
        }
        Time.timeScale = 1f;
        // Debug.Log("Player Died Event");
        Destroy(gameObject);
    }

    private void Died()
    {
        // TurnOffShield();
        AudioManager.instance.PlayOneShot("Player_Death");
        IsDie = true;
        DestroyAbilities();
        Time.timeScale = 0.25f;
        StartCoroutine(WaitPlayerDie(WaitTime));
        animator.SetBool("IsDie", true);
    }

    private void DestroyAbilities()
    {
        PlayerAttack playerAttack = GetComponent<PlayerAttack>();
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerAttack != null) playerAttack.enabled = false;
        if (playerMovement != null) playerMovement.enabled = false;
    }
    private void OnDestroy()
    {
        GameStorageManager.gameInfo.playerInfo.gold = coin;
        GameStorageManager.SaveGameInfo();
    }
}
