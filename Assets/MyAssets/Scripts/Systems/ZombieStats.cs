using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class ZombieStats : CharacterStats
{
    public NavMeshAgent navMeshAgent;
    public CharacterControllerBase characterController;
    public SkinnedMeshRenderer charRenderer;
    public Material diedMat;

    Color killColor;

    public override void Die()
    {
        base.Die();
        DropManager.Instance.DropPrice(PriceType.Gold, gameObject.transform.position);
    }

    public override void TakeDamage(float _damage)
    {
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        _damage -= armor;
        currentHp -= _damage;

        ChangeToPct(currentHp, maxHp); //From StatBase

        if (currentHp <= 0)
        {
            CallIEDie();
        }
    }

    void CallIEDie()
    {
        //navMeshAgent.Stop();
        navMeshAgent.isStopped = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        hpBarObj.SetActive(false);

        characterController.enabled = false;

        //charRenderer.material = diedMat;
        //charRenderer.material.color = Color.Lerp(charRenderer.material.color, Color.gray,0.1f);

        //DOTween.To(() => charRenderer.material.color, x => charRenderer.material.color = x, Color.gray, 1.5f);
        //killColor = Color.gray;
        //DOTween.To(() => charRenderer.material.color, x => charRenderer.material.color = x, Color.gray, 5f);
        //DOTween.To(() => killColor.a, x => killColor.a = x, 0, 5f);
        charRenderer.material.DOColor(diedMat.color, 5f);
        //GetComponentInChildren<SkinnedMeshRenderer>().material.DOFade(0, 5f);
        //charRenderer.material.DO

        StartCoroutine(IEDie());
    }


    IEnumerator IEDie()
    {
        gameObject.layer = LayerMask.NameToLayer("Died");
        GetComponentInChildren<Animator>().enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

