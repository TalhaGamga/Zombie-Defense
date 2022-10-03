using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;

    Vector3 direction;
    private Animator anim;

    private void Start()
    {
        //anim = GetComponentInChildren<Animator>();
    }
    private void Update()  
    {
        Move();
    }

    void Move()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                direction = (raycastHit.point - transform.position).normalized;
                var rot = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360 * Time.deltaTime);
            }

            //Run();

            transform.Translate(Vector3.Lerp(Vector3.zero, direction * runSpeed * Time.deltaTime, 1), Space.World);
        }

        else
        {
            //Idle();
        }
    }
    //private void Idle()
    //{
    //    anim.SetFloat("Speed", 0, 0.2f, Time.deltaTime);
    //}

    //private void Run()
    //{
    //    anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
    //}
}
