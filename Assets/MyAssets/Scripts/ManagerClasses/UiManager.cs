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

    private void OnEnable()
    {
        EventManager.OnSettingPrice += SetPrice;
    }

    private void OnDisable()
    {
        EventManager.OnSettingPrice -= SetPrice;
    }

    private void Start()
    {
        playerManager = PlayerManager.Instance;
    }

    public void SetPrice(PriceType tag, float price)
    {
        playerManager.priceDict[tag].SetPrice(price);

        SetPriceUi(tag);
    }

    public void SetPriceUi(PriceType tag)
    {
        playerManager.priceDict[tag].SetPriceUi();
    }

    public void OpenMarket()
    {
        UiMarket.gameObject.SetActive(true);
        //PlayerManager.Instance.OnPanelOpenedOrClosed();
        EventManager.OnStoppingGame?.Invoke();
    }
    public void CloseMarket()
    {
        UiMarket.gameObject.SetActive(false);
        //PlayerManager.Instance.OnPanelOpenedOrClosed();
        EventManager.OnPlayingGame?.Invoke();
    }
}
