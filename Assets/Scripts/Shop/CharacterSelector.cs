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

    public void SelectCharactor(int index)
    {
        currentPlayer = index;
        CharacterShop characterShop = charactorShops[index];
        if (index == 0)
        {
            priceButton.enabled = false;
            priceText.text = "EQUIPPPED";
            priceText.color = Color.red;
            coinImage.enabled = false;
        }
        else
        {
            priceButton.enabled = true;
            coinImage.enabled = true;
            priceText.color = Color.black;
            priceText.text = characterShop.price.ToString();
        }
     
        playerImage.sprite = characterShop.sr;
        nameText.text = characterShop.name;
        abilityText.text = "Damage: +" + characterShop.damage + "ATK\n" +
            "Speed: " + characterShop.speed +"\n"
            +characterShop.ability;
       
    }

    public void BuyCharacter()
    {
        Debug.Log("Character Selector - Buy Character " + currentPlayer);
    }

}
