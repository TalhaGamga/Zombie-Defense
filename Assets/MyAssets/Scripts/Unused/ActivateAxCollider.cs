using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ActivateAxCollider : MonoBehaviour
{

    [SerializeField] GameObject axCollider;
    [SerializeField] Animator playerAnim;
    public void CallEnableAxCollider()
    {
        StartCoroutine(IEActivateAxCollider());
    }

    IEnumerator IEActivateAxCollider()
    {
        axCollider.SetActive(true);
        axCollider.transform.DOPunchScale(Vector3.one * 7, 0.2f, 1, 1);
        axCollider.transform.DOPunchPosition(Vector3.forward * 4, 0.2f, 1, 1);
        yield return new WaitForSeconds(0.2f);
        axCollider.SetActive(false);

        playerAnim.ResetTrigger("AxAttack");
    }
}
