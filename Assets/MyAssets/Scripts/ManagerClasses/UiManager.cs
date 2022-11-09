using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UiManager : Singleton<UiManager>
{
    public GameObject UiMarket;
    public Camera mainCamera;

    PlayerManager playerManager;

    private void Start()
    {
        playerManager = PlayerManager.Instance;
    }

    public void SetPrice(PriceType tag, float price)
    {
        playerManager.priceDict[tag].SetPrice(price);

        SetPriceUi(tag);
    }

    void SetPriceUi(PriceType tag)
    {
        playerManager.priceDict[tag].SetPriceUi();
    }

    public void OpenMarket()
    {
        UiMarket.gameObject.SetActive(true);
        PlayerManager.Instance.OnPanelOpenedOrClosed();
    }
    public void CloseMarket()
    {
        UiMarket.gameObject.SetActive(false);
        PlayerManager.Instance.OnPanelOpenedOrClosed();
    }
}
