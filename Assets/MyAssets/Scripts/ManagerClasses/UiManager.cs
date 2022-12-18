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
    }

    public void SetPrice(PriceType tag, float price)
    {
        PlayerManager.Instance.priceDict[tag].SetPrice(price);

        SetPriceUi(tag);
    }

    public void SetPriceUi(PriceType tag)
    {
        PlayerManager.Instance.priceDict[tag].SetPriceUi();
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
