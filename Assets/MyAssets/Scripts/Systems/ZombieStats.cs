using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class ZombieStats : EnemyStats
{
    public NavMeshAgent navMeshAgent;
    public CharacterControllerBase characterController;
    public SkinnedMeshRenderer charRenderer;
    public Material diedMat;

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
        navMeshAgent.isStopped = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        hpBarObj.SetActive(false); 

        characterController.enabled = false;

        Destroy(charRenderer.materials[1]);
        Destroy(charRenderer.materials[2]);
        
        charRenderer.material.DOColor(diedMat.color, 5f);
      
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

