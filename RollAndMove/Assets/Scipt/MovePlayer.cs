using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float speed = 10.0f;
    float gravity = 20.0f;
    float jumpspeed = 8f;
    float rotatespeed = 5f;

    Vector3 move = Vector3.zero;

    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controller.isGrounded)
        {
            Debug.Log("Key press");

            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= speed;

            if (Input.GetButton("Jump"))
            {
                move.y = jumpspeed;
            }
        }

        move.y -= gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotatespeed, 0);

    }
}
