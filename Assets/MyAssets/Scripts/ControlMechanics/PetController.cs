using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PetController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform petLocalPos;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, petLocalPos.position, 5*Time.deltaTime);
    }
}
