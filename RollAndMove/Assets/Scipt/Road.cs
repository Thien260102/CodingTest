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
            
            
            Item item = Instantiate(Items[1]);
            item.gameObject.transform.SetParent(child);
            item.Init(child.position, ItemType.UseImmediately, ItemUseFor.PushBack3Block);

            if (distance == 0)
            {
                distance = UnityEngine.Random.Range(4, 7);

                //if (isBonus)
                //{
                //    Item item = Instantiate(Items[1]);
                //    item.gameObject.transform.SetParent(child);
                //    item.Init(child.position);
                //    //child.gameObject.GetComponent<Renderer>().material
                //    //    = Materials.Find(element => element.Key == MATERIAL.BonusSector).Value;
                //    //child.tag = MATERIAL.BonusSector.ToString();
                //}
                //else
                //{
                //    Item item = Instantiate(Items[0]);
                //    item.gameObject.transform.SetParent(child);
                //    item.Init(child.position);

                //    //child.gameObject.GetComponent<Renderer>().material
                //    //    = Materials.Find(element => element.Key == MATERIAL.FailSector).Value;
                //    //child.tag = MATERIAL.FailSector.ToString();
                //}

                //Debug.Log(isBonus);
                isBonus = !isBonus;
            }
            //else
                //child.tag = MATERIAL.Normal.ToString();


            RoadPoints.Add(child.gameObject);
        }
        //RoadPoints[RoadPoints.Count - 1].tag = MATERIAL.Normal.ToString(); // to sure end not bonus or fail sector

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

    #endregion

}
