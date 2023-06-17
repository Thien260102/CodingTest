using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Road : MonoBehaviour
{
    static Road instance;
    public static Road Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    #region Fields
    [SerializeField]
    List<Item> Items;

    List<GameObject> RoadPoints;
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

        //Load all road points
        LoadRoadPoints();
    }

    #endregion

    #region My Events

    void LoadRoadPoints()
    {
        int distance = UnityEngine.Random.Range(4, 7); // distance between bonus and fail sector
        bool isBonus = true; 

        RoadPoints = new List<GameObject>();

        foreach (Transform child in transform)
        {
            distance--; 
            
            if (distance == 0)
            {
                distance = UnityEngine.Random.Range(4, 7);

                if (isBonus)
                {
                    Item item = Instantiate(Items[0]);
                    item.gameObject.transform.SetParent(child);
                    item.Init(child.position);
                }
                else
                {
                    Item item = Instantiate(Items[1]);
                    item.gameObject.transform.SetParent(child);
                    item.Init(child.position);

                }

                isBonus = !isBonus;
            }


            RoadPoints.Add(child.gameObject);
        }

        Item Lastitem = GetItemOnWayPoint(RoadPoints.Count - 1); // to sure end not bonus or fail sector
        if (Lastitem != null)
            Destroy(Lastitem.gameObject);
    }

    public Item GetItemOnWayPoint(int index)
    {
        if (index < RoadPoints.Count && index >= 0 && RoadPoints[index].transform.childCount > 0)
            return RoadPoints[index].transform.GetChild(0).gameObject.GetComponent<Item>();

        return null;
    }
    

    public Vector3 GetRoadPoint(int index)
    {
        if (index < RoadPoints.Count && index >= 0)
            return RoadPoints[index].transform.position;

        return Vector3.zero;
    }

    public Vector3 GetLastRoadPoint()
    {
        if (RoadPoints.Count > 0)
            return RoadPoints[RoadPoints.Count - 1].transform.position;

        return Vector3.zero;
    }

    #endregion

}
