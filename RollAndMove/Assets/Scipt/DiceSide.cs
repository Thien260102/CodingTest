using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{
    #region Fields
    bool onGround;

    int value;

    #endregion

    #region System Events
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

    #endregion

    #region My Events

    public bool isOnGround() { return onGround; }

    public int getValue() { return value; }

    #endregion

}
