using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState: int
{
    IDLE = 0,
    WALK = 1,
}

public class Player : MonoBehaviour
{

    #region Fields
    public int NextPoint { get; set; }
    [SerializeField]
    float Speed;

    [SerializeField]
    Animator Animator;

    int State;
    public bool IsWin { get; set; }

    public int Turns { get; set; }

    public bool IsMyTurn { get; set; }

    public bool IsCompleteTurn { get; set; }

    bool hasRoll { get; set; }

    int RollValue;

    #endregion

    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        NextPoint = 1;
        SetState(PlayerState.IDLE);

        Turns = 0;
        IsWin = false;
        IsCompleteTurn = false;
        hasRoll = false;
        RollValue = 0;
    }

    #endregion

    #region My Events

    public void MyUpdate()
    {
        if(IsMyTurn)
        {
            Playing();
            //Debug.Log("Has roll: " + hasRoll);
            //Debug.Log("Is Complete Turn: " + IsCompleteTurn);
        }
    }

    void Playing()
    {
        if(!IsCompleteTurn)
        {
            if(!hasRoll)
            {
                Dice.Instance.CanRolling = true;

                if(Dice.Instance.IsCanGetValue)
                {
                    Dice.Instance.CanRolling = false;
                    hasRoll = Dice.Instance.IsCanGetValue;
                }
            }
            else
            {
                if (Dice.Instance.IsCanGetValue)
                    RollValue = Dice.Instance.getValue();
                else
                {
                    if(RollValue > 0)
                        MoveTo(Road.Instance.GetRoadPoint(NextPoint));
                    else if(RollValue < 0)
                    {
                        MoveTo(Road.Instance.GetRoadPoint(NextPoint), -1);
                    }
                    else 
                    {
                        SetState(PlayerState.IDLE);
                        //this will get some item if current road point has. 
                        Debug.Log("Next Point:" + NextPoint);

                        Item item = Road.Instance.GetItemOnWayPoint(NextPoint - 1);
                        
                        if(item != null)
                        {
                            Debug.Log(item.Type);
                            if (item.Type == ItemType.UseImmediately)
                            {
                                Debug.Log(item.UseFor);
                                switch(item.UseFor)
                                {
                                    case ItemUseFor.PlusOneTurn:
                                        Turns++;
                                        hasRoll = false;
                                        break;

                                    case ItemUseFor.PushBack3Block:
                                        NextPoint -= 2;
                                        RollValue = -3;
                                        break;
                                }
                            }

                        }
                        else 
                            EndTurn();
                        
                    }
                }
            }
        }
    }

    void EndTurn()
    {
        IsCompleteTurn = true;
        hasRoll = false;
        Turns++;
        Debug.Log("End Turn: " + IsCompleteTurn);
    }

    public bool MoveTo(Vector3 Destination, int isFront = 1)
    {
        if(Destination == Vector3.zero)
        {
            if(RollValue >= 0)
            {
                RollValue = 0;
                IsWin = true;
                return false;
            }
            else
            {
                RollValue = 0;
                NextPoint++;
                return false;
            }
        }

        Vector3 newPosition = Vector3.MoveTowards(transform.position, Destination, Speed * Time.deltaTime);
        if (transform.position != newPosition)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, Destination - transform.position, Speed * Time.deltaTime, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            // https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.position = newPosition;

            SetState(PlayerState.WALK);
            return true; // Move;
        }

        
        NextPoint += isFront;
        RollValue -= isFront;
        return false;    // Idle
    }

    public void SetState(PlayerState state)
    {
        State = (int)state;
        Animator.SetInteger("State", State);
    }

    #endregion

}
