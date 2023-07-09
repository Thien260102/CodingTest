using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    static WebCamTexture webcamera;

    // Start is called before the first frame update
    void Start()
    {
        if (webcamera == null)
            webcamera = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = webcamera;

        if (!webcamera.isPlaying)
            webcamera.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
