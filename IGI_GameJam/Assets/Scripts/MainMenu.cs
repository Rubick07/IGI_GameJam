using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Save saveSo;

    private void Start()
    {
        AudioManager.Instance.PlayMusic("MainMenu");
    }

    public void ChangeScene(string scenename)
    {
        if(saveSo.Attempt == 0)
        {
            SceneManager.LoadScene("Prologue");
        }
        else
        {
            SceneManager.LoadScene(scenename);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Keluar");
        Application.Quit();
    }

}
