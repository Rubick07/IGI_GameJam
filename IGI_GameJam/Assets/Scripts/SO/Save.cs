using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SaveFile", menuName = "SaveFile")]
public class Save : ScriptableObject
{
    public int Currency;
    public int Score;
    public int Attempt;
    public float Time;

    public void SaveManager()
    {
        SaveSystem.SaveManaGer(this);
    }

    public void LoadManager()
    {
        ManagerData data = SaveSystem.LoadManager();
        Currency = data.Currency;
        Score = data.Score;
        Attempt = data.Attempt;
        Time = data.Time;
        
    }
}
