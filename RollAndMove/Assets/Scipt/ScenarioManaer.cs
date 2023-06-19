using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManaer : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject Effect;

    [SerializeField]
    Player OriginPlayerObject;
    List<Player> players;

    int TotalPlayer;

    int Turn;
    int currentPlayerTurn;

    int Place;

    #endregion


    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        Effect = Instantiate(Effect);

        if (DataManager.Instance != null)
        {
            TotalPlayer = DataManager.Instance.NumberOfPlayers();
            if (Road.Instance != null)
            {
                // Init player and add into List player
                players = new List<Player>();
                for (int i = 0; i < TotalPlayer; i++)
                {
                    Player Instantiate_Player = Instantiate(OriginPlayerObject);
                    Instantiate_Player.Name.text = DataManager.Instance.GetPlayerName(i);
                    Instantiate_Player.transform.position = Road.Instance.GetRoadPoint(0);

                    players.Add(Instantiate_Player);
                }

                if (players.Count > 0)
                    SetEffectAtPlayer(players[0].transform);

            }
        }
        

        currentPlayerTurn = 0;
        Turn = 1;
        Place = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(players != null)
        {
            foreach (Player p in players)
                if (!p.IsWin)
                {
                    PlayingGame();
                    return;
                }

            string result = "List Player: ";
            foreach (var item in DataManager.Instance.GetAllDatas())
            {
                result += item.ToString() + " // ";
            }
            Debug.Log(result);

            GameManager.Instance.NextScene();
        }
        
    }

    #endregion

    #region My Events

    void PlayingGame()
    {
        if (currentPlayerTurn < players.Count)
        {
            Player player = players[currentPlayerTurn];
            if (!player.IsWin)
            {
                player.IsMyTurn = true;
                player.MyUpdate();
                SetEffectAtPlayer(player.transform);

                if (player.IsCompleteTurn)
                {
                    if(player.IsWin)
                    {
                        int index = DataManager.Instance.GetIndexByName(player.Name.text);
                        DataManager.Instance.SetPlayerData(index, Place++, player.Name.text, player.Turns, player.Bonus, player.Fail);
                        player.ShowFloatingText("Finish");
                    }

                    currentPlayerTurn++;
                    if (currentPlayerTurn == players.Count)
                    {
                        currentPlayerTurn = 0;
                        Turn++;
                    }
                    //Debug.Log("index: " + currentPlayerTurn);
                    player.IsCompleteTurn = false;
                    player.IsMyTurn = false;
                }
            }
            else
            {
                currentPlayerTurn++;
                if (currentPlayerTurn == players.Count)
                {
                    currentPlayerTurn = 0;
                    Turn++;
                }
            }
        }
    }

    void SetEffectAtPlayer(Transform player)
    {
        //Effect.transform.SetParent(player.transform);

        Vector3 position = player.transform.position;
        position.y += 0.1f;
        Effect.transform.position = position;
    }

    #endregion

}
