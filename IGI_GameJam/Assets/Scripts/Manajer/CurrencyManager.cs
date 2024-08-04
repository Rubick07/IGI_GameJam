using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public Save save;
    public static CurrencyManager instance;

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
        
        save.LoadManager();
        DontDestroyOnLoad(gameObject);
    }
    public void AddCurrency(int currency)
    {
        save.Currency += currency;
    }

    public void MinusCurrency(int currency)
    {
        if (CheckCurrency(currency))
        {
        save.Currency -= currency;
        }
        else
        {
            Debug.Log("duit gk cukup");
        }
        
    }

    public bool CheckCurrency(int currency)
    {
        if (save.Currency >= currency)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddAttempt()
    {
        save.Attempt++;
    }

    private void OnApplicationQuit()
    {
        save.SaveManager();
    }
}
