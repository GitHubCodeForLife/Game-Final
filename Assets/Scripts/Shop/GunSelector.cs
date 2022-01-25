using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunSelector : MonoBehaviour
{
    public List<GunShop> gunShops;
  
    public Button priceButton;
    public Image coinImage;
    public Image weaponImage;
    public Text nameText;
    public Text abilityText;
    public Text priceText;

    private int currentGun = 0;


    private void Awake()
    {
        InitialGuns();
        ReadGuns();
        SelectGuns(0);
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
        if (GameStorageManager.shopInfo.guns != null) return;
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

    public void SelectGuns(int index)
    {
        if (priceButton == null) return;
        currentGun = index;
      
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
    public void BuyGun()
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
            int price = GameStorageManager.shopInfo.guns[currentGun].price;
            bool purchase = ShopKeeper.instance.Purchase(price);
            if (purchase == false) return;

            //Remember Check Gold before BUY
            GameStorageManager.shopInfo.guns[currentGun].state = STATE_ITEM.BOUGHT;
        }
        GameStorageManager.SaveShopInfo();
        ReadGuns();
        SelectGuns(currentGun);
    }

}
