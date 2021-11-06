using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Awake()
    {
        TriggerDialouge();
    }
    public void TriggerDialouge() 
    {
        //FindObjectOfType<DialogueManager>().StartDialog(dialogue);
        //GameManager.gameState = GAME_STATE.CHARACTER_MOVING;
     } 
}

