using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public List<WeaponShop> weaponShops;
    public Image weaponImage;
    public Image coinImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;
    public Button priceButton;

    private int currentWeapon = 0;

    public void SelectWeapon(int index)
    {
        currentWeapon = index;
        WeaponShop weaponShop = weaponShops[index];
        //if (index == 0)
        //{
        //    priceButton.enabled = false;
        //    priceText.text = "EQUIPPPED";
        //    priceText.color = Color.red;
        //    coinImage.enabled = false;
        //}
        //else
        //{
        //    priceButton.enabled = true;
        //    coinImage.enabled = true;
        //    priceText.color = Color.black;
        //    priceText.text = weaponShop.price.ToString();
        //}

        weaponImage.sprite = weaponShop.sr;
        nameText.text = weaponShop.name;
        abilityText.text = "Damage: +" + weaponShop.damage + "ATK\n" +
               weaponShop.ability;

    }

    public void BuyWeapon()
    {
        Debug.Log("Character Selector - Buy Weapon " + currentWeapon);
    }


}
