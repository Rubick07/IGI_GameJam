using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Save save;
    public static GameManager instance;
    private int Score;
    public float time;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        InvokeRepeating("TimeScore", 0f, 1f);
        AudioManager.Instance.PlayMusic("Battle");
    }
    public void SetHighScore()
    {
        if(save.Score < Score)
        {
            save.Score = Score;
        }
        if(save.Time > time)
        {
            save.Time = time;
        }
        
    }

    
    public void AddScore(int score)
    {
        Score += score;
    }

    public void AddAttempt()
    {
        save.Attempt++;
    }

    public void TimeScore()
    {
        time += 1;
    }
}
