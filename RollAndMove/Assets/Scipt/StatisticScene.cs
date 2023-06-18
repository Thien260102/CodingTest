using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticScene : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject ContentGridLayout;

    [SerializeField]
    RowDataUI DataUI;

    #endregion

    #region System Events
    // Start is called before the first frame update
    void Start()
    {
        LoadDataIntoUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region My Events

    public void LoadDataIntoUI()
    {
        var PlayersData = DataManager.Instance.GetHighPlace();
        foreach (var element in PlayersData)
        {
            var row = Instantiate(DataUI, ContentGridLayout.transform).GetComponent<RowDataUI>();
            row.Place.text = element.Place.ToString();
            row.PlayerName.text = element.Name;
            row.Turns.text = element.Turns.ToString();
            row.BonusSectors.text = element.BonusSector.ToString();
            row.FailSectors.text = element.FailSector.ToString();
        }
    }

    public void BackToMainMenu()
    {
        GameManager.Instance.BackToMainMenu();
    }

    #endregion

}
