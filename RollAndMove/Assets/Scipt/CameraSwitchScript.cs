using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchScript : MonoBehaviour
{
    public GameObject CameraOne;
    public GameObject CameraTwo;

    AudioListener CameraOneAudioListener;
    AudioListener CameraTwoAudioListener;

    // Start is called before the first frame update
    void Start()
    {
        CameraOneAudioListener = CameraOne.GetComponent<AudioListener>();
        CameraTwoAudioListener = CameraTwo.GetComponent<AudioListener>();

        CameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }

    void SwitchCamera()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            CameraChangeCounter();
        }
    }

    void CameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        CameraPositionChange(cameraPositionCounter);
    }

    void CameraPositionChange(int CameraPosition)
    {
        if (CameraPosition > 1)
            CameraPosition = 0;

        //Set camera position into database
        PlayerPrefs.SetInt("CameraPosition", CameraPosition);

        //Set camera position 1
        if(CameraPosition == 0)
        {
            CameraOne.SetActive(true);
            CameraOneAudioListener.enabled = true;

            CameraTwo.SetActive(false);
            CameraTwoAudioListener.enabled = false;
        }
        else if(CameraPosition == 1)
        {
            CameraOne.SetActive(false);
            CameraOneAudioListener.enabled = false;

            CameraTwo.SetActive(true);
            CameraTwoAudioListener.enabled = true;
        }
        

    }


}
