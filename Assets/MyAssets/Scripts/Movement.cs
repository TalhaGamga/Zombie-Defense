using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed;
    private Vector3 moveDirection;
    private Vector3 rotateDirection;
    private Animator anim;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        float rotateY = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(0, 0, moveZ);
        rotateDirection = new Vector3(0, rotateY, 0);

        if (moveDirection != Vector3.zero || rotateDirection != Vector3.zero)
        {
            Run();
        }

        else if (moveDirection == Vector3.zero)
        {
            Idle();
        }

        transform.Translate(moveDirection * Time.deltaTime);
        transform.Rotate(rotateDirection * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.2f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        moveDirection *= runSpeed;
        rotateDirection *= rotateSpeed;
    }
}
