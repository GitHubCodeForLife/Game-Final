using System;
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
    public Text quantityText;
    public Button priceButton;

    private int currentAbility  = 0 ;

    private void Awake()
    {
        InitialItems();
        ReadItems();
        SelectAbility(0);
    }

    private void ReadItems()
    {
        List<AbilityInfo> abilities = GameStorageManager.shopInfo.abilities;
        for (int i = 0; i < abilities.Count; i++)
        {
            abilityShops[i].ability = abilities[i].ability;
            abilityShops[i].quantity = abilities[i].quantity;
            abilityShops[i].name = abilities[i].name;
            abilityShops[i].price = abilities[i].price;
        }
    }

    private void InitialItems()
    {
        List<AbilityInfo> abilities = new List<AbilityInfo>();
        foreach (AbilityShop abilityShop in abilityShops)
        {
            AbilityInfo abilityInfo = new AbilityInfo();
            abilityInfo.name = abilityShop.name;
            abilityInfo.price = abilityShop.price;
            abilityInfo.quantity = abilityShop.quantity;
            abilityInfo.ability = abilityShop.ability;
            abilities.Add(abilityInfo);
        }

        GameStorageManager.shopInfo.abilities = abilities;
        GameStorageManager.SaveShopInfo();
    }

    public void SelectAbility(int index)
    {
        if (priceButton == null) return;
        currentAbility = index;
        AbilityShop abilityShop = abilityShops[index];

        abilityImage.sprite = abilityShop.sr;
        nameText.text = abilityShop.name;
        abilityText.text = abilityShop.ability;
        quantityText.text = abilityShop.quantity.ToString();
    } 

    public void BuyAbility()
    {
        //Check Gold
        //Buy 
        GameStorageManager.shopInfo.abilities[currentAbility].quantity++;
        GameStorageManager.SaveShopInfo();
        ReadItems();
        SelectAbility(currentAbility);
        Debug.Log("Abitlity Selector - Buy Ability " + currentAbility);
    }

}
