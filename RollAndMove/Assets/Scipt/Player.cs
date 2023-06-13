using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState: int
{
    IDLE = 0,
    WALK = 1,
}

public class Player : MonoBehaviour
{
    public int CurrentPoint { get; set; }
    [SerializeField]
    float Speed;

    [SerializeField]
    Animator Animator;

    int State;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPoint = 0;
        State = (int)PlayerState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetInteger("State", State);
    }

    public bool MoveTo(Vector3 Destination)
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, Destination, Speed * Time.deltaTime);
        if (transform.position != newPosition)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, Destination - transform.position, Speed * Time.deltaTime, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            // https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.position = newPosition;

            SetState((int)PlayerState.WALK);
            return true; // Move;
        }

        SetState((int)PlayerState.IDLE);
        CurrentPoint++;
        return false;    // Idle
    }

    void SetState(int state)
    {
        State = state;
        Animator.SetInteger("State", state);
    }

}
