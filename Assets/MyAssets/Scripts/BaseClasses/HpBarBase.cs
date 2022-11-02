using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class HpBarBase : MonoBehaviour
{
    public Image foregroundImage;
    public virtual void HandleHpChanged(float pct)
    {
        ChangeToPct(pct);
    }

    public virtual void ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        foregroundImage.fillAmount = pct;
    }
}
