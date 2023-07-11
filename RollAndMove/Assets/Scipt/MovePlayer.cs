using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float speed = 10.0f;
    float gravity = 20.0f;
    float jumpspeed = 8f;
    float rotatespeed = 5f;

    Vector3 PlayerMove = Vector3.zero;

    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            Debug.Log("Key press");

            float move = Input.GetAxis("Vertical");
            if (move == 0)
                move = TouchControl.playerMoveAxisTouch;

            PlayerMove = new Vector3(0, 0, move);
            PlayerMove = transform.TransformDirection(PlayerMove);
            PlayerMove *= speed;

            if (Input.GetButton("Jump"))
            {
                PlayerMove.y = jumpspeed;
            }
        }

        PlayerMove.y -= gravity * Time.deltaTime;
        controller.Move(PlayerMove * Time.deltaTime);

        float rotate = Input.GetAxis("Horizontal");
        if (rotate == 0)
            rotate = TouchControl.playerTurnAxisTouch;

        transform.Rotate(0, rotate * rotatespeed, 0);

    }
}