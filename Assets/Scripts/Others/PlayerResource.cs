using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour

{
    public Text textCoin;
    private int coin;
    private int life;
    public Text textLife;

    PlayerResource()
    {
        //Read Coin and Life from Local Storage
        coin = 10;
        life = 3;
    }
    private void Awake()
    {
        textCoin.text = this.coin.ToString();
        textLife.text = this.life.ToString();
    }
    public void ChangeCoin(int coin)
    {
        this.coin += coin;
        textCoin.text = this.coin.ToString();
    }
    public void ChangeLife(int life)
    {
        this.life += life;
        textLife.text = this.life.ToString();
    } 
    public bool IsDied()
    {
        return life == 0;
    }
}
