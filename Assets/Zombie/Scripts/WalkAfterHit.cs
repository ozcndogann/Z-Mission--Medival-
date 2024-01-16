using UnityEngine;
using UnityEngine.AI;

public class WalkAfterHit : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        
        Vector3 pos = animator.transform.position;
        Vector3 dir = (player.position - pos).normalized;
        walk.Position = /*pos + dir * 8*/player.position;
        animator.SetBool("isWalking", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void onstateupdate(animator animator, animatorstateýnfo stateýnfo, int layerýndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
