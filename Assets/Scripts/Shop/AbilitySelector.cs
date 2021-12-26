using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelector : MonoBehaviour
{
    public List<AbilityShop> abilityShops;
    public Image abilityImage;
    public Image coinImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;
    public Button priceButton;

    private int currentAbility  = 0 ;
    public void SelectAbility(int index)
    {
        currentAbility = index;
        AbilityShop abilityShop = abilityShops[index];

        abilityImage.sprite = abilityShop.sr;
        nameText.text = abilityShop.name;
        abilityText.text = abilityShop.ability;

    } 

    public void BuyAbility()
    {
        Debug.Log("Character Selector - Buy Weapon " + currentAbility);
    }

}
