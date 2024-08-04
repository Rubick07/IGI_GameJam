using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    public bool StartDialogue;
    //public GameObject button;
    int index = 0;

    private void Start()
    {
        if (StartDialogue)
        {
            Invoke("NewDialogue", 0.1f);
        }
    }

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //Debug.Log(index);
        DialogueManager.Instance.SimpenDialog(dialogue);

    }

    public void NewDialogue()
    {
        index = 0;
        Debug.Log("index =" + index);
        TriggerDialogue();
    }
}
