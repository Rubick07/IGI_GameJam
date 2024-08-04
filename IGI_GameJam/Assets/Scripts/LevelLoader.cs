using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitiontime;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevelWithIndex(int indexlevel)
    {
        StartCoroutine(LoadLevel(indexlevel));
    }

    IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(index);

    }

}
