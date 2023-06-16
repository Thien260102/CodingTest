using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private static Dice instance;
    public static Dice Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    #region Fields

    [SerializeField]
    List<DiceSide> DiceSides;

    Rigidbody Body;

    Vector3 OriginPosition;

    bool isRolling;

    public bool IsStop { get; private set; }

    public bool CanRolling { get; set; }

    public bool IsCanGetValue { get; private set; }

    #endregion

    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        // just need load one time
        DontDestroyOnLoad(this);

        Body = GetComponent<Rigidbody>();
        
        OriginPosition = transform.position;

        isRolling = false;

        CanRolling = false;

        IsCanGetValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRolling && Input.GetKeyDown(KeyCode.Space))
            Roll();
        if (isRolling && Body.IsSleeping())
            ResetDice();
    }

    #endregion

    #region My Events

    public void Roll()
    {
        if (!isRolling)
        {
            isRolling = true;
            IsStop = false;

            Body.AddForce(Random.Range(-10, 10), Random.Range(200, 300), 0, ForceMode.Force);

            float valueRandom = Random.Range(-1000, 1000);
            Body.AddTorque(valueRandom / Random.Range(1, 5),
               valueRandom / Random.Range(5, 10),
                valueRandom / Random.Range(15, 20));

        }
    }

    private void ResetDice()
    {
        transform.position = OriginPosition;
        isRolling = false;
        IsStop = true;
        CanRolling = false;
        IsCanGetValue = true;
    }

    public int getValue()
    {
        IsCanGetValue = false;

        foreach(var element in DiceSides)
        {
            if(element.isOnGround())
            {
                switch(element.getValue())
                {
                    case 1:
                        return 6;
                    case 2:
                        return 5;

                    case 3:
                        return 4;

                    case 4:
                        return 3;

                    case 5:
                        return 2;

                    case 6:
                        return 1;
                }
            }
        }    

        return -1;
    }


    #endregion
}
