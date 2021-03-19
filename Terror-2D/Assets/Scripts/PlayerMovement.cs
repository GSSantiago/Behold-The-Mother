using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;


    public Vector2 moveDir;
    bool isIdle;

    Vector2 movement;
    Vector2 lastmoveDir;

    private void Start()
    {
        anim.SetBool("Ismove", false);


    }

    // Update is called once per frame
    void Update()
    {
        movement.x = 0f;
        movement.y = 0f;

        if (Input.GetKey(KeyCode.W))
            movement.y = +1f;

        if (Input.GetKey(KeyCode.S))
            movement.y = -1f;

        if (Input.GetKey(KeyCode.A))
            movement.x = -1f;

        if (Input.GetKey(KeyCode.D))
            movement.x = +1f;

       

        moveDir = new Vector3(movement.x, movement.y).normalized;

     

        bool isIdle = movement.x == 0 && movement.y == 0;

        if (isIdle)
        {
            //Idle
            rb.velocity = Vector2.zero;
            anim.SetBool("Ismove", false);
            anim.SetBool("Isrun", false);
        }

        else
        {
            //Moving

            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Running
                anim.SetBool("Isrun", true);
                moveSpeed = 8f;//Aumentando a velocidade
            }
            else
            {
                //Not Running
                anim.SetBool("Isrun", false);
                moveSpeed = 5f;//Definindo a velocidade para o padrão
            }

            lastmoveDir = moveDir;
            rb.velocity = moveDir * moveSpeed;

            anim.SetBool("Ismove", true);
            anim.SetFloat("Horizontal", moveDir.x);
            anim.SetFloat("Vertical", moveDir.y);
        }
       
      
    }

}
