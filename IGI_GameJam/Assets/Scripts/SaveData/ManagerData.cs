using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManagerData 
{
    public int Currency;
    public int Score;
    public int Attempt;
    public float Time;
    public ManagerData(Save Savedata)
    {
        Currency = Savedata.Currency;
        Score = Savedata.Score;
        Attempt = Savedata.Attempt;
        Time = Savedata.Time;

    }

}
