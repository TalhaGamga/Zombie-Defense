using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private DoorController doorController;

    private void Awake()
    {
        doorController.OnHpPctChanged += HandleHpChanged;
    }

    private void HandleHpChanged(float pct)
    {
        ChangeToPct(pct);
    }

    private void ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        foregroundImage.fillAmount = pct;
    }
}
