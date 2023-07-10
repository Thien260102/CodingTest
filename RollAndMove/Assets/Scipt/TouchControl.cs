using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public static int playerTurnAxisTouch = 0;
    public static int playerMoveAxisTouch = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTurnAxisTouch = 0;   
    }

    public void PlayerLeftUIPointerDown()
    {
        playerTurnAxisTouch = -1;
    }

    public void PlayerLeftUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    public void PlayerRightUIPointerDown()
    {
        playerTurnAxisTouch = 1;
    }

    public void PlayerRightUIPointerUp()
    {
        playerTurnAxisTouch = 0;
    }

    public void PlayerMoveUIPointerDown()
    {
        playerMoveAxisTouch = 1;
    }

    public void PlayerMoveUIPointerUp()
    {
        playerMoveAxisTouch = 0;
    }

}
