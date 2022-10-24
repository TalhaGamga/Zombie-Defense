using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAxCollider : MonoBehaviour
{

    [SerializeField] GameObject axCollider;
    public void CallEnableAxCollider()
    {
        StartCoroutine(IEActivateAxCollider());
    }

    IEnumerator IEActivateAxCollider()
    {
        axCollider.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        axCollider.SetActive(false);

    }
}
