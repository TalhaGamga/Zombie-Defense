using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorBaseState currentState;
    public SolidState solidState = new SolidState();
    public BrokenState brokenState = new BrokenState();

    void Start()
    {
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(DoorState state)
    {
        switch (state)
        {
            case DoorState.solid:
                currentState = solidState;
                break;

            case DoorState.broken:
                currentState = brokenState;
                break;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this);
    }
}
