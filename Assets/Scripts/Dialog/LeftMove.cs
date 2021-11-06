using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    public Dialogue dialogue;
    public RightMove rightMove;
    // Start is called before the first frame update
    private void Awake()
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
           
            rightMove.Trigger();
            Destroy(gameObject, 1);
           // WaitSeconds(0.5f);
            
            //Trigger Right Move

        }
    }
    IEnumerator WaitSeconds(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
