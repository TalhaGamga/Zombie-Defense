using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ActivatePunchCollider : MonoBehaviour
{
    [SerializeField] GameObject punchCollider;

    public void CallActivatePunchCollider()
    {
        StartCoroutine(IEActivatePunchCollider());
    }

    IEnumerator IEActivatePunchCollider()
    {
        punchCollider.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        punchCollider.SetActive(false);
    }
}