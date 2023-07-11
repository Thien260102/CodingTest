using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerAroundEarth : MonoBehaviour
{
    public float Speed = 10f;

    Vector3 Direction;

    public Earth earth;
    private Transform playerTransform;

    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
        body.constraints = RigidbodyConstraints.FreezeRotation;

        playerTransform = transform;

        earth = GameObject.Find("Earth").GetComponent<Earth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + playerTransform.TransformDirection(Direction) * Speed);

        if (earth)
        {
            earth.Attract(playerTransform);
            Debug.Log("Attract");
        }
    }
}
