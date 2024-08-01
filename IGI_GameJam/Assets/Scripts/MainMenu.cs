using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string Stage)
    {
        SceneManager.LoadScene(Stage);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar");
        Application.Quit();
    }

}
