using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManaer : MonoBehaviour
{
    [SerializeField]
    Player OriginPlayerObject;
    List<Player> players;

    [SerializeField]
    int TotalPlayer;

    int Turn;
    int currentPlayerTurn;

    bool isEnd;


    // Start is called before the first frame update
    void Start()
    {
        if(Road.Instance != null)
        {
            // Init player and add into List player
            players = new List<Player>();
            for (int i = 0; i < TotalPlayer; i++)
            {
                Player Instantiate_Player = Instantiate(OriginPlayerObject);
                players.Add(Instantiate_Player);
            }

            // set start position for all player
            foreach (Player player in players)
                player.transform.position = Road.Instance.GetRoadPoint(0);
        }

        currentPlayerTurn = 0;
        Turn = 1;

        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPlayerTurn < players.Count)
        {
            Player player = players[currentPlayerTurn];
            if (!player.IsWin && player.Turns != Turn)
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
                    player.IsCompleteTurn = false;
                    player.IsMyTurn = false;
                }
            }
        }
        
    }
}
