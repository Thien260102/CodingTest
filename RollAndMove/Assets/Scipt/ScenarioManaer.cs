using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManaer : MonoBehaviour
{
    #region Fields

    [SerializeField]
    Player OriginPlayerObject;
    List<Player> players;

    int TotalPlayer;

    int Turn;
    int currentPlayerTurn;

    bool isEnd;

    #endregion


    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        TotalPlayer = DataManager.Instance.NumberOfPlayers();
        if(Road.Instance != null)
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

        }

        currentPlayerTurn = 0;
        Turn = 1;

        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Player p in players)
            if (!p.IsWin)
            {
                PlayingGame();
                return;
            }

        isEnd = true;
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

                if (player.IsCompleteTurn)
                {
                    currentPlayerTurn++;
                    if (currentPlayerTurn == players.Count)
                    {
                        currentPlayerTurn = 0;
                        Turn++;
                    }
                    Debug.Log("index: " + currentPlayerTurn);
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

    #endregion

}
