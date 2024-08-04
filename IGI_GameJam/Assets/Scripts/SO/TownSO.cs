using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TownFile", menuName = "TownFile")]
public class TownSO : ScriptableObject
{
    public int HospitalsLevel;
    public int ResearchLevel;
    public int CulinaryLevel;
    public int MilitaryLevel;
    public int AgricultureLevel;

    public void SaveTown()
    {
        SaveSystem.SaveTown(this);
    }

    public void LoadTown()
    {
        TownData townData = SaveSystem.LoadTown();

        HospitalsLevel = townData.HospitalsLevel;
        ResearchLevel = townData.ResearchLevel;
        CulinaryLevel = townData.CulinaryLevel;
        MilitaryLevel = townData.MilitaryLevel;
        AgricultureLevel = townData.AgricultureLevel;



    }


}
