using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeSelector : MonoBehaviour
{
    public List<GrenadeShop> grenadeShops;
    public Button priceButton;
    public Image coinImage;
    public Image weaponImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;

    private int currentGrenade = 0;

    private void Awake()
    {
        InitialGrenades();
        ReadGrenades();
        SelectGrenade(0);
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

    void InitialGrenades()
    {
        if (GameStorageManager.shopInfo.grenades != null) return;
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

    public void SelectGrenade(int index)
    {
        currentGrenade = index;
       
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

    public void BuyGrenade()
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

}
