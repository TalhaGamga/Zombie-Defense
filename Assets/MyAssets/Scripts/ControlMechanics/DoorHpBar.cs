using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorHpBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private DoorStateManager stateManager;

    private void Awake()
    {
        stateManager.OnHpPctChanged += HandleHpChanged;
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
