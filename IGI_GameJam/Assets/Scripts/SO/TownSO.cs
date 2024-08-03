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

}
