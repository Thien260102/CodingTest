using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Fields
    [SerializeField]
    List<GameObject> Objects;

    [SerializeField]
    GameObject Model;

    [SerializeField]
    GameObject InputName;

    TMP_InputField Name;
    TMP_Text Order;
    TMP_Text Notify;

    int totalPayers = 0;

    #endregion


    #region System Events

    // Start is called before the first frame update
    void Start()
    {
        if(InputName != null)
        {
            Name = InputName.transform.Find("Name").GetComponent<TMP_InputField>();
            Order = InputName.transform.Find("PlayerOrder").GetComponent<TMP_Text>();
            Notify = InputName.transform.Find("Notify").GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) // Click Enter
        {
            EnterName();
        }
    }

    #endregion

    #region My Events

    void EnterName()
    {
        if (InputName.activeSelf && Name != null && Order != null && Name.text != "")
        {
            if (DataManager.Instance != null)
            {
                if (DataManager.Instance.IsExistName(Name.text))
                {
                    Notify.gameObject.SetActive(true);
                    return;
                }
                Notify.gameObject.SetActive(false);

                DataManager.Instance.SetPlayerName(Name.text);

                Debug.Log(Name.text);
                // reset
                Name.text = "";
                Order.text = "Player " + (DataManager.Instance.NumberOfPlayers() + 1) + ':';

                if (DataManager.Instance.NumberOfPlayers() == totalPayers)
                {
                    GameManager.Instance.NextLevel();
                    return;
                }
            }
        }
    }

    public void StartGame(int index)
    {
        TMP_InputField NumberOfPlayers = Objects[index].transform.Find("InputField").GetComponent<TMP_InputField>();

        int number;
        if(NumberOfPlayers != null && int.TryParse(NumberOfPlayers.text, out number))
        {
            if(number >= 2 && number <= 4)
            {
                totalPayers = number;
                Debug.Log(totalPayers);
                NavigateTo(1); // Display Model, Input Name
            }
        }
    }

    public void NavigateTo(int index)
    {
        foreach (GameObject canvas in Objects)
        {
            canvas.SetActive(false);
        }
        if(index >= 0 && index < Objects.Count)
        {
            Objects[index].SetActive(true);
            if (Objects[index].name == "InputName")
            {
                Model.SetActive(true);
            }
            else
            {
                Model.SetActive(false);
            }
        }
    }

    public void LoadLevel(int level)
    {
        GameManager.Instance.LoadLevel(level);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    #endregion
}
