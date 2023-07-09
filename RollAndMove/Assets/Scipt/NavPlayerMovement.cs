using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPlayerMovement : MonoBehaviour
{
    NavMeshAgent navPlayer;

    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        navPlayer = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        SetState(PlayerState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (navPlayer.velocity == Vector3.zero)
            SetState(PlayerState.IDLE);
        else
            SetState(PlayerState.WALK);

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                navPlayer.SetDestination(hit.point);
            }
        }
    }

    public void SetState(PlayerState state)
    {
        int State = (int)state;
        Animator.SetInteger("State", State);
    }

}
