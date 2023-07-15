using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState
{
    Idle = 0,
    OpenAnimation = 1,
    Open = 2,
    CloseAnimation = 3,
}

public class DoorScript : MonoBehaviour
{
    Animator animator;

    DoorState State;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        State = DoorState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetState(DoorState state)
    {
        State = state;
        animator.SetInteger("State", (int)state);
        
    }

    public void DoorOpenAnimationDone()
    {
        SetState(DoorState.Open);
    }

    public void DoorCloseAnimationDone()
    {
        SetState(DoorState.Idle);
    }    

    private void OnTriggerEnter(Collider other)
    {
        SetState(DoorState.OpenAnimation);
    }

    private void OnTriggerExit(Collider other)
    {
        SetState(DoorState.CloseAnimation);
    }
}
