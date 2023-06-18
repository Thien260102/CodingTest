using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    #region System Events

    void Awake()
    {
        if (instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }


    #endregion

    #region My Events

    public void NextScene()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetScene()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int level)
    {
        if (level >= 0 && level < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(level);
    }

    public void BackToMainMenu()
    {
        if (SceneManager.sceneCountInBuildSettings > 0)
        {
            DataManager.Instance.ClearData();
            SceneManager.LoadScene(0);
        }
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

}
