using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TownData
{
    public int HospitalsLevel;
    public int ResearchLevel;
    public int CulinaryLevel;
    public int MilitaryLevel;
    public int AgricultureLevel;

    public TownData(TownSO townSO)
    {
        HospitalsLevel = townSO.HospitalsLevel;
        ResearchLevel = townSO.ResearchLevel;
        CulinaryLevel = townSO.CulinaryLevel;
        MilitaryLevel = townSO.MilitaryLevel;
        AgricultureLevel = townSO.AgricultureLevel;

    }

}
