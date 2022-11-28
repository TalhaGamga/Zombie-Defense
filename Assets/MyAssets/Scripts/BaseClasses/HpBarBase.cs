using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class HpBarBase : MonoBehaviour
{
    public Image foregroundImage;
    private void Update()
    {
        Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
        transform.forward = new Vector3(0, direction.y, direction.z);
    }

    public virtual void HandleHpChanged(float pct)
    {
        ChangeToPct(pct);
    }

    public virtual void ChangeToPct(float pct)
    {
        foregroundImage.fillAmount = pct;
    }
}
