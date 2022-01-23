using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public List<GunShop> gunShops;
    public List<GrenadeShop> grenadeShops;
    public Button priceButton;
    public Image coinImage;
    public Image weaponImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;

    private WEAPON_TYPE currentWeapon;
    private int currentGun = 0;
    private int currentGrenade = 0;

    private void Awake()
    {
       // InitialGuns();
      //  InitialGrenades();
        ReadGuns();
        ReadGrenades();
        SelectGuns(0);
    }

    private void ReadGrenades()
    {
        List<GrenadeInfo> grenades = GameStorageManager.shopInfo.grenades;
        for (int i = 0; i < grenades.Count; i++)
        {
            grenadeShops[i].ability = grenades[i].ability;
            grenadeShops[i].price = grenades[i].price;
            grenadeShops[i].name = grenades[i].name;
            grenadeShops[i].state = grenades[i].state;
        }
    }

    private void ReadGuns()
    {
        List<GunInfo> guns = GameStorageManager.shopInfo.guns;
        for (int i = 0; i < guns.Count; i++)
        {
            gunShops[i].ability = guns[i].ability;
            gunShops[i].price = guns[i].price;
            gunShops[i].name = guns[i].name;
            gunShops[i].state = guns[i].state;
        }
    }

    void InitialGuns()
    {
        List<GunInfo> guns = new List<GunInfo>();
        foreach (GunShop gunShop in gunShops)
        {
            GunInfo gunInfo = new GunInfo();
            gunInfo.name = gunShop.name;
            gunInfo.price = gunShop.price;
            gunInfo.state = gunShop.state;
            gunInfo.ability = gunShop.ability;
            guns.Add(gunInfo);
        }

        GameStorageManager.shopInfo.guns = guns;
        GameStorageManager.SaveShopInfo();
    }
    void InitialGrenades()
    {
        List<GrenadeInfo> grenades = new List<GrenadeInfo>();
        foreach (GrenadeShop grenadeShop in grenadeShops)
        {
            GrenadeInfo grenadeInfo = new GrenadeInfo();
            grenadeInfo.name = grenadeShop.name;
            grenadeInfo.price = grenadeShop.price;
            grenadeInfo.state = grenadeShop.state;
            grenadeInfo.ability = grenadeShop.ability;
            grenades.Add(grenadeInfo);
        }
        GameStorageManager.shopInfo.grenades = grenades;
        GameStorageManager.SaveShopInfo();
    }
    public void SelectGuns(int index)
    {
        currentGun = index;
        currentWeapon = WEAPON_TYPE.GUN;
        GunShop gunShop = gunShops[index];
        if (gunShop.state == STATE_ITEM.ON_SELL)
        {
            priceButton.enabled = true;
            coinImage.enabled = true;
            priceText.text = gunShop.price.ToString();
            priceText.color = Color.black;

        }
        else if (gunShop.state == STATE_ITEM.BOUGHT)
        {
            priceButton.enabled = true;
            coinImage.enabled = false;
            priceText.color = Color.black;
            priceText.text = gunShop.state.ToString();
        }
        else
        {
            priceButton.enabled = false;
            coinImage.enabled = false;
            priceText.color = Color.red;
            priceText.text = gunShop.state.ToString();
        }


        weaponImage.sprite = gunShop.sr;
        nameText.text = gunShop.name;
        abilityText.text = "Damage: +" + gunShop.damage + "ATK\n" 
            + gunShop.ability;
    }
    public void SelectGrenade(int index)
    {
        currentGrenade = index;
        currentWeapon = WEAPON_TYPE.GRENADE;
        GrenadeShop grenadeShop = grenadeShops[index];
        if (grenadeShop.state == STATE_ITEM.ON_SELL)
        {
            priceButton.enabled = true;
            coinImage.enabled = true;
            priceText.text = grenadeShop.price.ToString();
            priceText.color = Color.black;

        }
        else if (grenadeShop.state == STATE_ITEM.BOUGHT)
        {
            priceButton.enabled = true;
            coinImage.enabled = false;
            priceText.color = Color.black;
            priceText.text = grenadeShop.state.ToString();
        }
        else
        {
            priceButton.enabled = false;
            coinImage.enabled = false;
            priceText.color = Color.red;
            priceText.text = grenadeShop.state.ToString();
        }


        weaponImage.sprite = grenadeShop.sr;
        nameText.text = grenadeShop.name;
        abilityText.text = "Damage: +" + grenadeShop.damage + "ATK\n"
            + grenadeShop.ability;
    }

    public void BuyWeapon()
    {
        if (currentWeapon == WEAPON_TYPE.GUN)
        {
            Debug.Log("Weapon selector  - Buy Gun " + currentGun);
            BuyGun();
        }
        else
        {
            Debug.Log("Weapon selector  - Buy Grenade " + currentGrenade);
            BuyGrenade();
        }
    }

    private void BuyGrenade()
    {
        if (GameStorageManager.shopInfo.grenades[currentGrenade].state == STATE_ITEM.BOUGHT)
        {
            for (int i = 0; i < GameStorageManager.shopInfo.grenades.Count; i++)
            {
                if (GameStorageManager.shopInfo.grenades[i].state == STATE_ITEM.EQUIPPED)
                {
                    GameStorageManager.shopInfo.grenades[i].state = STATE_ITEM.BOUGHT; break;
                }
            }

            GameStorageManager.shopInfo.grenades[currentGrenade].state = STATE_ITEM.EQUIPPED;
        }
        else
        {
            //Remember Check Gold before BUY
            GameStorageManager.shopInfo.grenades[currentGrenade].state = STATE_ITEM.BOUGHT;
        }
        GameStorageManager.SaveShopInfo();
        ReadGrenades();
        SelectGrenade(currentGrenade);
    }

    private void BuyGun()
    {
        if (GameStorageManager.shopInfo.guns[currentGun].state == STATE_ITEM.BOUGHT)
        {
            for (int i = 0; i < GameStorageManager.shopInfo.guns.Count; i++)
            {
                if (GameStorageManager.shopInfo.guns[i].state == STATE_ITEM.EQUIPPED)
                {
                    GameStorageManager.shopInfo.guns[i].state = STATE_ITEM.BOUGHT; break;
                }
            }

            GameStorageManager.shopInfo.guns[currentGun].state = STATE_ITEM.EQUIPPED;
        }
        else
        {
            //Remember Check Gold before BUY
            GameStorageManager.shopInfo.guns[currentGun].state = STATE_ITEM.BOUGHT;
        }
        GameStorageManager.SaveShopInfo();
        ReadGuns();
        SelectGuns(currentGun);
    }
  
}
