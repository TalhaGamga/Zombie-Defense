using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorHpBar : HpBarBase
{
    [SerializeField]
    private DoorStateManager doorStateManager;

    private void Awake()
    {
        doorStateManager.stats.OnHpPctChanged += HandleHpChanged;
    }

    //private void HandleHpChanged(float pct)
    //{
    //    ChangeToPct(pct);
    //}

    //private void ChangeToPct(float pct)
    //{
    //    float preChangePct = foregroundImage.fillAmount;
    //    foregroundImage.fillAmount = pct;
    //} 
}
