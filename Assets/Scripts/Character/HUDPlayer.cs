using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPlayer : MonoBehaviour
{
    public Text cointText;
    public Text lifeText;

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
}
