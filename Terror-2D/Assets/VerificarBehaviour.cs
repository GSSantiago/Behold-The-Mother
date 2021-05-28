using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarBehaviour : StateMachineBehaviour
{

    public EnemyPatrol patrol;
    public EnemyFOV fov;
    public EnemyOpenDoor EOD;
    public Porta insideP;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyPatrol>();
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<EnemyFOV>();
        EOD = GameObject.FindGameObjectWithTag("EnemyOpenDoor").GetComponent<EnemyOpenDoor>();

        patrol.isChecking = true;
        EOD.isChecking = true;
        patrol.Verificar();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fov.isplayerFound)
        {
            animator.SetBool("Isverificando", false);
            animator.SetBool("Isperseguindo", true);
        }

        if(patrol.InimigoIA.reachedEndOfPath)
        {
            animator.SetBool("Isverificando", false);
            animator.SetBool("Ispatrulhando", true);
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol.isChecking = false;
        EOD.isChecking = false;

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
