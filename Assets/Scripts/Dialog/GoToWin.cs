using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWin : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    public void Trigger()
    {
        TriggerDialouge();
    }
    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().StartDialog(dialogue, SetGameState);
    }

    public void SetGameState()
    {
        GameManager.gameState = GAME_STATE.DIALOGUE_ENDING;
    }
}
