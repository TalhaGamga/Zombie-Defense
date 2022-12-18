using UnityEngine;
using System;
using TMPro;
using System.Collections.Generic;

public class PlayerManager : Singleton<PlayerManager>
{
    public List<Price> prices = new List<Price>();
    [SerializeField]
    public Dictionary<PriceType, Price> priceDict = new Dictionary<PriceType, Price>();

    public Action OnPanelOpenedOrClosed;

    public PlayerStats stats;

    public GameObject player;
    public GameObject equippedItem;
    public Transform collectPoint;
    public Transform bagObj;

    void Awake()
    {
        foreach (Price price in prices)
        {
            priceDict.Add(price.tag, price);
        }

        EventManager.GetPlayer += GetPlayerManager;
    }

    private void OnDisable()
    {
        EventManager.GetPlayer -= GetPlayerManager;
    }

    PlayerManager GetPlayerManager()
    {
        return this;
    }

}

[Serializable]
public class Price
{
    public PriceType tag;
    public float currentPrice = 0;
    public TextMeshProUGUI priceText;

    public void SetPrice(float price)
    {
        currentPrice += price;
        SetPriceUi();
    }

    public void SetPriceUi()
    {
        priceText.text = currentPrice.ToString();
    }
}
