using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UiManager : Singleton<UiManager>
{
    public TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI pfPoppingUpGold;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] Transform popUpPos;

    public GameObject UiMarket;
    public Camera mainCamera;

    private void Start()
    {
        InitGoldText();
    }
    public void SetGoldOnMarket(float price)
    { 
        float currentGold = PlayerManager.Instance.gold;

        float targetGold = currentGold - price;

        PlayerManager.Instance.gold = targetGold;
        UiManager.Instance.goldText.text = targetGold.ToString();
    }

    public void SetGoldOnCollect(float price)
    {
        float currentGold = PlayerManager.Instance.gold;

        float targetGold = currentGold + price;

        PlayerManager.Instance.gold = targetGold; 

        UiManager.Instance.goldText.text = targetGold.ToString();
    }
    public IEnumerator PLayPopUpGold(float price)
    {
        TextMeshProUGUI effect = Instantiate(pfPoppingUpGold, popUpPos.position, Quaternion.identity, uiCanvas.transform);
        effect.text = price.ToString();
        effect.transform.DOLocalMoveY(transform.localPosition.y + 50, .2f);
        effect.transform.DOScale(transform.localScale + Vector3.one / 3, 0.2f);
        yield return new WaitForSeconds(.2f);

        Destroy(effect.gameObject);
    }

    public void CallIEPlayPopUpGold(float price)
    {
        StartCoroutine(PLayPopUpGold(price));
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

    //IEnumerator IESetGoldOnCollect(float price) 
    //{
    //    float currentGold = PlayerManager.Instance.gold;
    //    float targetGold = currentGold + price;

    //    PlayerManager.Instance.gold = targetGold;

    //    while (currentGold < targetGold)
    //    {
    //        currentGold++;
    //        UiManager.Instance.goldText.text = currentGold.ToString();
    //        yield return new WaitForSeconds(.1f);
    //    }
    //}

    void InitGoldText() 
    {
        goldText.text = PlayerManager.Instance.gold.ToString();
    }
}
