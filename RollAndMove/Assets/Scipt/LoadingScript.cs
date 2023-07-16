using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField]
    Slider SliderBar;

    [SerializeField]
    TMP_Text Text;

    // Start is called before the first frame update
    void Start()
    {
        // hide slider progress bar in start
        SliderBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Show slider progress
            SliderBar.gameObject.SetActive(true);

            Text.text = "Loading ....";

            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next >= SceneManager.sceneCount)
            yield return 0;

        AsyncOperation async = SceneManager.LoadSceneAsync(next);

        while(!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            SliderBar.value = progress;
            Text.text = progress * 100f + "%";
            yield return 0;
        }

    }    
}
