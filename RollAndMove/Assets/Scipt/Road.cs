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

    public List<GameObject> RoadPoints;
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
        RoadPoints = new List<GameObject>();
        foreach (Transform child in transform)
        {
            RoadPoints.Add(child.gameObject);
        }
    }

    public Vector3 GetRoadPoint(int index)
    {
        if (index < RoadPoints.Count)
            return RoadPoints[index].transform.position;

        return Vector3.zero;
    }
}
