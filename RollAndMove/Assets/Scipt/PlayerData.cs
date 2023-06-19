using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class PlayerData
{
    #region Properties

    public int Place;
    public string Name;
    public int Turns;
    public int BonusSector;
    public int FailSector;

    #endregion

    #region Methods
    public PlayerData()
    {
        Place = 0;
        Name = "";
        Turns = 1;
        BonusSector = 0;
        FailSector = 0;
    }

    public override string ToString()
    {
        return "Place: " + Place 
            + ", Name: " + Name 
            + ", Turns:" + Turns 
            + ", Bonus: " + BonusSector 
            + ", Fail: " + FailSector;
    }

    #endregion
}
