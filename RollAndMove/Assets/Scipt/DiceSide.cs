using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    bool onGround;

    int value;
    // Start is called before the first frame update
    void Start()
    {
        onGround = false;
        value = int.Parse(gameObject.name);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Ground")
            onGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Ground")
            onGround = false;
    }

    public bool isOnGround() { return onGround; }

    public int getValue() { return value; }
}
