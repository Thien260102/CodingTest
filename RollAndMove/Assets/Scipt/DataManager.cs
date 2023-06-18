using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    List<PlayerData> PlayersData;

    #endregion


    #region System Events
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        PlayersData = new List<PlayerData>();

        DontDestroyOnLoad(this);
    }

    #endregion

    #region My Events
    public void AddNewPlayerData()
    {
        if (PlayersData == null)
            PlayersData = new List<PlayerData>();

        PlayerData data = new PlayerData();
        PlayersData.Add(data);
    }

    public int NumberOfPlayers() 
    { 
        return PlayersData.Count; 
    }

    public void SetPlayerName(int index, string name)
    {
        if (index >= 0 && index < PlayersData.Count)
            PlayersData[index].Name = name;
    }

    public string GetPlayerName(int index)
    {
        if (index >= 0 && index < PlayersData.Count)
            return PlayersData[index].Name;

        return "";
    }

    public bool IsExistName(string name)
    {
        if (PlayersData.Find(e => e.Name == name) != null)
            return true;

        return false;
    }

    public void SetPlayerPlace(int index, int place)
    {
        if (index >= 0 && index < PlayersData.Count)
            PlayersData[index].Place = place;
    }

    public void SetPlayerTurn(int index, int turns)
    {
        if (index >= 0 && index < PlayersData.Count)
            PlayersData[index].Turns = turns;
    }

    public void SetBonusSector(int index, int bonus)
    {
        if (index >= 0 && index < PlayersData.Count)
            PlayersData[index].BonusSector = bonus;
    }

    public void SetFailSector(int index, int fail)
    {
        if (index >= 0 && index < PlayersData.Count)
            PlayersData[index].FailSector = fail;
    }

    public int GetIndexByName(string name)
    {
        if (PlayersData.Count > 0)
            return PlayersData.FindIndex(e => e.Name == name);

        return -1; // not found
    }

    public void SetPlayerData(int index, int place, string name, int turns, int bonus, int fail)
    {
        if(index >= 0 && index < PlayersData.Count)
        {
            PlayerData data = PlayersData[index];
            data.Place = place;
            data.Name = name;
            data.Turns = turns;
            data.BonusSector = bonus;
            data.FailSector = fail;
        }
    }

    public List<PlayerData> GetAllDatas()
    {
        return new List<PlayerData>(PlayersData);
    }

    public IEnumerable<PlayerData> GetHighPlace()
    {
        return new List<PlayerData>(PlayersData).OrderBy(x => x.Place);
    }

    public void ClearData() { PlayersData.Clear(); }

    #endregion


}
