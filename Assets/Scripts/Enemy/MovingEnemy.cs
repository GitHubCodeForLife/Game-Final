using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : StateMachineBehaviour
{
    private float timer;
    private Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        timer = Random.Range(enemy.minIdleTimer, enemy.maxIdleTimer);
        if (enemy.transform.localScale.x == -1)
            animator.transform.localScale = new Vector3(1, 1, 1);
        else animator.transform.localScale = new Vector3(-1, 1, 1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.IsFreeze() == true) return;
        if (timer <= 0)
            animator.SetTrigger("Idle");
        else
            timer -= Time.deltaTime;
        if (enemy.PlayerInSight())
        {
            Debug.Log("Enemy Attack Player");
            animator.SetTrigger("Attack"); return;
        }
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector2 pos = enemy.transform.position;
        pos.x += enemy.speed * Time.deltaTime * enemy.transform.localScale.x;
        enemy.transform.position = pos;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
