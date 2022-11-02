using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopItemManager : MonoBehaviour
{
    public float price;
    private string explanation;

    public ShopItemScriptableObject shopItem;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI priceText;

    private void Awake()
    {
        price = shopItem.price;

        explanation = shopItem.itemInfo;
        infoText.text = explanation;
        priceText.text = price.ToString();
    }

    public void MovementSpeedUp()
    {
        if (PlayerManager.Instance.gold > shopItem.price)
        {
            PlayerManager.Instance.stats.movementSpeed= PlayerManager.Instance.stats.movementSpeed* 1.2f;

            UiManager.Instance.SetGoldOnMarket(shopItem.price);

            UpdatePrice();
        }

    }

    public void AttackSpeedUp()
    {
        if (PlayerManager.Instance.gold > shopItem.price)
        {

            PlayerManager.Instance.stats.reattackSpeed= PlayerManager.Instance.stats.reattackSpeed * 0.8f;


            UiManager.Instance.SetGoldOnMarket(shopItem.price);
            UpdatePrice();
        }
    }

    public void AttackPowerUp()
    {
        if (PlayerManager.Instance.gold > shopItem.price)
        {

            float previousDmg = PlayerManager.Instance.stats.damage;
            PlayerManager.Instance.stats.damage = previousDmg * 1.2f;


            UiManager.Instance.SetGoldOnMarket(shopItem.price);

            UpdatePrice();
        }
    }

    public void ArmorUp()
    {
        if (PlayerManager.Instance.gold > shopItem.price)
        {
            float currentArmor = PlayerManager.Instance.stats.armor;
            float upgradedArmor = currentArmor * 1.2f;

            PlayerManager.Instance.stats.armor= upgradedArmor;

            UiManager.Instance.SetGoldOnMarket(shopItem.price);

            UpdatePrice();
        }
    }
    void UpdatePrice()
    {
        price *= 2;
        shopItem.price = price;

        priceText.text = price.ToString();
    }
}

