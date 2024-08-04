using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreditSound : MonoBehaviour
{
    public string nama;
    private void Start()
    {
        startmusic(nama);
    }
    public void startmusic(string name)
    {
        AudioManager.Instance.PlayMusic(name);
    }

}
