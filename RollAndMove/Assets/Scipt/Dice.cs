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

    [SerializeField]
    List<DiceSide> DiceSides;

    Rigidbody Body;

    Vector3 OriginPosition;

    bool isRolling;

    public bool IsStop { get; private set; }

    public bool CanRolling { get; set; }

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
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRolling && Input.GetKeyDown(KeyCode.Space))
            Roll();
        if (isRolling && Body.IsSleeping())
            ResetDice();
    }

    public void Roll()
    {
        if (!isRolling)
        {
            isRolling = true;
            Body.AddTorque(Random.Range(10000, 50000), Random.Range(1000, 5000), Random.Range(2000, 5000));
            Body.AddForce(Random.Range(10, 50), Random.Range(100, 300), Random.Range(10, 30), ForceMode.Force);
        }
    }

    private void ResetDice()
    {
        transform.position = OriginPosition;
        isRolling = false;
        IsStop = true;
        CanRolling = false;
        Debug.Log(getValue());
    }

    public int getValue()
    {
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

    public bool IsRolling() { return isRolling; }
}
