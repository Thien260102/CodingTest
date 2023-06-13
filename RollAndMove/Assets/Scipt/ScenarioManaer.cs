using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManaer : MonoBehaviour
{
    [SerializeField]
    List<GameObject> WayPoints;

    [SerializeField]
    List<Player> players;

    int Turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Count > 0)
        {
            if(players[0].CurrentPoint < WayPoints.Count)
                players[0].MoveTo(WayPoints[players[0].CurrentPoint].transform.position);
        }
    }
}
