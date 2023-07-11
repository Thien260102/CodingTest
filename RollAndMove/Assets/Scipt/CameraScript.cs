using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("SimplePlayer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 targetPosition = new Vector3(Target.transform.position.x,
        //                                    transform.position.y,
        //                                    Target.transform.position.z);
        Vector3 targetPosition = new Vector3(Target.transform.position.x,
                                            Target.transform.position.y,
                                            Target.transform.position.z);

        transform.LookAt(targetPosition);
    }
}
