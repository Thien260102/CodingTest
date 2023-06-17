using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager instance;
    public static DataManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    #region Fields
    List<string> PlayersName = new List<string>();

    #endregion


    #region System Events
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    #endregion

    #region My Events
    public int NumberOfPlayers() 
    { 
        return PlayersName.Count; 
    }

    public void SetPlayerName(string name)
    {
        PlayersName.Add(name);
    }

    public string GetPlayerName(int index)
    {
        if (index >= 0 && index < PlayersName.Count)
            return PlayersName[index];

        return "";
    }

    public bool IsExistName(string name)
    {
        if (PlayersName.Find(e => e == name) != null)
            return true;

        return false;
    }

    #endregion


}
