using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildingBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;
    private void Awake()
    {
        GetComponentInParent<Building>().OnBuildingPctChanged += HandleBuildingChanged;
    }

    private void HandleBuildingChanged(float pct)
    {
        ChangeToPct(pct);
    }

    private void ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;

        foregroundImage.fillAmount = pct;
    }
}
