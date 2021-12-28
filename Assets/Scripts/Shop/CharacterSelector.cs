using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public List<CharacterShop> charactorShops;
    public Image playerImage;
    public Image coinImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;
    public Button priceButton;

    private int currentPlayer =  0;

    private void Awake()
    {
        InitialItems();
        ReadItems();
        SelectCharactor(0);
    }

    private void ReadItems()
    {
        List<CharacterInfo> characters = GameStorageManager.shopInfo.characters;
        for(int i = 0; i < characters.Count; i++)
        {
            charactorShops[i].ability = characters[i].ability;
            charactorShops[i].price = characters[i].price;
            charactorShops[i].name = characters[i].name;
            charactorShops[i].state = characters[i].state;
        }
    }

    private void InitialItems()
    {
        List<CharacterInfo> characters = new List<CharacterInfo>();
        foreach (CharacterShop characterShop in charactorShops)
        {
            CharacterInfo characterInfo = new CharacterInfo();
            characterInfo.name = characterShop.name;
            characterInfo.price = characterShop.price;
            characterInfo.state = characterShop.state;
            characterInfo.ability = characterShop.ability;
            characters.Add(characterInfo);
        }
      
        GameStorageManager.shopInfo.characters = characters;
        GameStorageManager.SaveShopInfo();
    }

    public void SelectCharactor(int index)
    {
        currentPlayer = index;
        CharacterShop characterShop = charactorShops[index];
        if (characterShop.state == STATE_ITEM.ON_SELL)
        {
            priceButton.enabled = true;
            coinImage.enabled = true;
            priceText.text = characterShop.price.ToString();
            priceText.color = Color.black;
           
        }
        else if(characterShop.state == STATE_ITEM.BOUGHT)
        {
            priceButton.enabled = true;
            coinImage.enabled = false;
            priceText.color = Color.black;
            priceText.text = characterShop.state.ToString();
        }
        else {
            priceButton.enabled = false;
            coinImage.enabled = false;
            priceText.color = Color.red;
            priceText.text = characterShop.state.ToString();
        }

        
        playerImage.sprite = characterShop.sr;
        nameText.text = characterShop.name;
        abilityText.text = "Damage: +" + characterShop.damage + "ATK\n" +
            "Speed: " + characterShop.speed +"\n"
            +characterShop.ability;
       
    }

    public void BuyCharacter()
    {
        if (GameStorageManager.shopInfo.characters[currentPlayer].state == STATE_ITEM.BOUGHT) { 
            for(int i=0;i< GameStorageManager.shopInfo.characters.Count; i++)
            {
                if(GameStorageManager.shopInfo.characters[i].state == STATE_ITEM.EQUIPPED){
                    GameStorageManager.shopInfo.characters[i].state = STATE_ITEM.BOUGHT; break;
                }
            }

            GameStorageManager.shopInfo.characters[currentPlayer].state = STATE_ITEM.EQUIPPED;
        }
        else
        {
            //Remember Check Gold before BUY
            GameStorageManager.shopInfo.characters[currentPlayer].state = STATE_ITEM.BOUGHT;
        }
        GameStorageManager.SaveShopInfo();
        ReadItems();
        SelectCharactor(currentPlayer);
    }
}
