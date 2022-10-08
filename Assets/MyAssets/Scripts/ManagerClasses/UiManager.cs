using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UiManager : MonoBehaviour
{
    #region Singleton
    private static UiManager instance;
    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("UiManager").AddComponent<UiManager>();
            }

            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }
    #endregion

    public TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI pfPoppingUpGold;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] Transform popUpPos;
    public Camera mainCamera;

    private void Start()
    {
        SetGoldText();
    }
    public void SetGoldText()
    {
        goldText.text = PlayerManager.Instance.gold.ToString();
    }

    public IEnumerator PLayPopUpGold(int goldNum)
    {
        TextMeshProUGUI effect = Instantiate(pfPoppingUpGold, popUpPos.position, Quaternion.identity, uiCanvas.transform);
        effect.text = goldNum.ToString();
        effect.transform.DOLocalMoveY(transform.localPosition.y + 50, .2f); 
        effect.transform.DOScale(transform.localScale + Vector3.one/3, 0.2f); 
        yield return new WaitForSeconds(.2f);
        Destroy(effect);
    }

    public void CallIEPlayPopUpGold(int goldNum)
    {
        StartCoroutine(PLayPopUpGold(goldNum));
    }
}
