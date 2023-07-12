using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public float Gravity = -12;

    public void Attract(Transform objectTransform)
    {
        Vector3 gravityUp = (objectTransform.position - transform.position).normalized;
        Vector3 localUp = objectTransform.up;

        objectTransform.GetComponent<Rigidbody>().AddForce(gravityUp * Gravity);

        //Debug.Log(gravityUp * Gravity);

        Quaternion target = Quaternion.FromToRotation(localUp, gravityUp) * objectTransform.rotation;
        objectTransform.rotation = Quaternion.Slerp(objectTransform.rotation, target, 50f * Time.deltaTime);
    }
}
