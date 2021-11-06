using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator animator;
    public GameObject dialogBox;
    public delegate void SetGameStateDelegate();
    public SetGameStateDelegate setGameState;
    void Awake() { }
    public void StartDialog(Dialogue dialogue, SetGameStateDelegate setGameState)
    {
        GameManager.gameState = GAME_STATE.DIALOGUE_STARTING;
        dialogBox.SetActive(true);
        // animator.SetBool("IsOpen", true)
        Debug.Log("On Start");
        if (sentences == null)
            sentences = new Queue<string>();
        else
            sentences.Clear();
        foreach (string sentence in dialogue.sentences) { sentences.Enqueue(sentence); }
        nameText.text = dialogue.name;
        DisplayNextSentence();
        this.setGameState = setGameState;
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            Endialogue(); return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        for (int i = 0; i < sentence.Length; i++)
        {
            dialogueText.text += sentence[i];
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void Endialogue()
    {
        // animator.SetBool("IsOpen", false); 
        Debug.Log("End Dialogue");
        dialogBox.SetActive(false);
        if (this.setGameState != null)
            this.setGameState();
    }
}

