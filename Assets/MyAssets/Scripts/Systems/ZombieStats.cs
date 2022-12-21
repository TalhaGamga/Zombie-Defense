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
    [SerializeField] Animator anim;

    Rigidbody[] rigidBodies;
    Collider[] colliders;

    Color initColor;

    Material mat1, mat2;

    private void OnEnable()
    {
        gameObject.layer = LayerMask.NameToLayer("Zombie");
    }

    private void Start()
    {
        rigidBodies = transform.GetComponentsInChildren<Rigidbody>();
        colliders = transform.GetComponentsInChildren<Collider>();

        SetRagdoll(false);

        initColor = charRenderer.material.color;
        mat1 = charRenderer.materials[1];
        mat2 = charRenderer.materials[2];
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
        gameObject.layer = LayerMask.NameToLayer("Died");

        ObjectPooler.Instance.DropGold(transform.position, transform);

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
        SetRagdoll(true);

        yield return new WaitForSeconds(5f);
        ResetZombie();
        //Destroy(gameObject);
    }

    void SetRagdoll(bool isRagdoll)
    {
        anim.enabled = !isRagdoll;

        for (int i = 1; i < rigidBodies.Length; i++) rigidBodies[i].isKinematic = !isRagdoll;
        for (int j = 1; j < colliders.Length; j++) colliders[j].enabled = isRagdoll;

        rigidBodies[0].isKinematic = isRagdoll;
        colliders[0].enabled = !isRagdoll;
    }

    void ResetZombie()
    {
        SetRagdoll(false);
        charRenderer.materials[0].color = initColor;

        charRenderer.materials[1] = mat1;
        charRenderer.materials[2] = mat2;

        navMeshAgent.isStopped = false;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        hpBarObj.SetActive(true);

        characterController.enabled = true;

        transform.position = Vector3.zero;
        Revive();

        gameObject.SetActive(false);
    }
} 