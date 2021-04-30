using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PerseguirBehaviour : StateMachineBehaviour
{
    public EnemyPatrol patrulha;
    public EnemyFOV fov;
    public AudioSource PerseguicaoSom;

    public AudioSource[] sounds;
    public AudioSource stopPerseguir;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrulha = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyPatrol>();
        fov = GameObject.FindGameObjectWithTag("FOV").GetComponent<EnemyFOV>();
        PerseguicaoSom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        PerseguicaoSom.Play();
        PerseguicaoSom.volume = 1f;

        fov.CallTime();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrulha.perseguir();

        if (!fov.isPerseguindo)
        {
            animator.SetBool("Isperseguindo", false);
            animator.SetBool("Ispatrulhando", true);

        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Parando corotina");
        fov.StopTime();
        fov.isPerseguindo = false;
        patrulha.DiminuirVolume();
        //PerseguicaoSom.Stop();

        //sounds = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();
       // stopPerseguir = sounds[1];//era 1
        //stopPerseguir.Play();


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
