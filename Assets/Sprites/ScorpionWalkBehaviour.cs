using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionWalkBehaviour : StateMachineBehaviour
{
    public float timer;
    public float maxTimer;
    public float minTimer;

  
    private Transform playerPos;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTimer, maxTimer);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CountDownTimer(animator);

        FollowTarget(animator);

    }

    private void FollowTarget(Animator animator)
    {
        Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        //Debug.Log("Player Position: " + playerPos.position);
        //Debug.Log("Enemie Position: " + animator.transform.position);
        SetDirection(animator);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

    private void SetDirection(Animator animator)
    {
        //if (playerPos.position.x > animator.transform.position.x)
        //    animator.transform.rotation = new Quaternion(0, 180, 0, 0);
        //else animator.transform.rotation = new Quaternion(0, 0, 0, 0);
        if (playerPos.position.x > animator.transform.position.x)
            animator.GetComponent<SpriteRenderer>().flipX = true;
        else animator.GetComponent<SpriteRenderer>().flipX = false;
    }

    private void CountDownTimer(Animator animator)
    {
        if (timer <= 0)
            animator.SetTrigger("Idle");
        else
            timer -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
