using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public Image Character;
    public TMP_Text nameText;
    public TMP_Text DialogueText;
    public Button DialogueButton;
    public static DialogueManager Instance;
    [Header("Settings kelar dialog")]
    public bool NextScene;
    public bool StartGame;
    //public bool StartMiniGames;
    public int index = 0;
    public GameObject BackButton;

    private Dialogue[] dialoguePunyaManajer;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SimpenDialog(Dialogue[] dialogues)
    {
        dialoguePunyaManajer = dialogues;
        StartDialogue();
    }
    public void StartDialogue()
    {


        DialogueButton.enabled = true;
        DialogueButton.image.enabled = true;
        nameText.text = dialoguePunyaManajer[index].name;
        Character.enabled = true;
        Character.sprite = dialoguePunyaManajer[index].CharacterImage;
        sentences.Clear();

        foreach (string sentence in dialoguePunyaManajer[index].sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentences();
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentences(sentence));
        //DialogueText.text = sentence;

    }

    IEnumerator TypeSentences(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End Dialogue");
        StopAllCoroutines();
        //Character.color = new Color(255, 255, 255, 0.5f);
        DialogueText.text = "";
        nameText.text = "";
        //DialogueSelanjutnyaPunyaManager?.Invoke();
        if (index + 1 < dialoguePunyaManajer.Length)
        {
            index++;
            StartDialogue();
        }
        else
        {

            index = 0;
            DialogueManager.Instance.TurnOffTxtBox();


        }


    }

    public void TurnOffTxtBox()
    {
        Character.enabled = false;
        DialogueButton.enabled = false;
        DialogueButton.image.enabled = false;
        DialogueText.text = "";
        nameText.text = "";
    }



}
