using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPlayer : MonoBehaviour
{
    public Text cointText;
    public Text lifeText;
    public Text bulletText;
    public Text grenadeText;

    public static HUDPlayer instance { get; private set; }
    private void Awake()
    {
        instance = this;
    }

    public void SetLifeText(int life)
    {
        lifeText.text = life.ToString();
    }
    public void SetCoinText(int coin)
    {
        cointText.text = coin.ToString();
    }

    internal void SetGrenade(int grenadeNumber)
    {
        grenadeText.text = grenadeNumber.ToString();
        if (grenadeNumber > 0)
        {
            grenadeText.color = Color.green;
        }
        else
        {
            grenadeText.color = Color.red;
        } 
    }

    internal void SetBullet(int bulletNumber)
    {
        bulletText.text = bulletNumber.ToString();
        if (bulletNumber > 0)
        {
            bulletText.color = Color.green;
        }
        else
        {
            bulletText.color = Color.red;
        }
    }
}
