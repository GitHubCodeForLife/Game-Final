using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMove : MonoBehaviour
{
    public Dialogue dialogue;
    public JumpMove jumpMove;   
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
        GameManager.gameState = GAME_STATE.CHARACTER_MOVING;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject, 1);
            //Trigger Right Move
            jumpMove.Trigger();
        }
    }
}
