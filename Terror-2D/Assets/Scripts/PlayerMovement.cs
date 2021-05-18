using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    public float normalSpeed = 5f;
    public float runSpeed = 8f;
    [SerializeField] Rigidbody2D rb;
    public Animator anim;
    public bool changeControl;

    [SerializeField] StaminaBar staminabar;

    public Vector2 moveDir;
    public Vector2 movement;

    //[SerializeField] Dialog dialog;

    private void Start()
    {

        anim.SetBool("Ismove", false);
        changeControl = false;
    }

    #region Movimento
    void Update()
    {
        movement.x = 0f;
        movement.y = 0f;

        //Verificação se os controles devem ser mudados devido a sanidade baixa
        if (!changeControl)
            normalControl();
        else
            twistedControl();

        moveDir = new Vector3(movement.x, movement.y).normalized;

        bool isIdle = movement.x == 0 && movement.y == 0;

        if (isIdle)
        {
            Idle();
        }
        else
        {
            //Moving
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (staminabar.currentStamina > 0)
                {
                    //Running
                    anim.SetBool("Isrun", true);
                    moveSpeed = runSpeed;//Aumentando a velocidade
                    staminabar.UseStamina(0.5f);
                }
                else
                {
                    //Not Stamina
                    anim.SetBool("Isrun", false);
                    moveSpeed = normalSpeed;//Definindo a velocidade para o padr�o
                }
            }
            else
            {
                anim.SetBool("Isrun", false);
                moveSpeed = normalSpeed;//Definindo a velocidade para o padr�o
            }
            rb.velocity = moveDir * moveSpeed;

            anim.SetBool("Ismove", true);
            anim.SetFloat("Horizontal", moveDir.x);
            anim.SetFloat("Vertical", moveDir.y);
        }


    }
    #endregion

    public void Idle()
    {
        rb.velocity = Vector2.zero;
        anim.SetBool("Ismove", false);
        anim.SetBool("Isrun", false);
    }

    public void ChangeLayer(bool change)
    {

        if (change == true)
            gameObject.layer = 0;

        if (change == false)
            gameObject.layer = 11;
    }

    private void normalControl()
    {
        if (Input.GetKey(KeyCode.W))
            movement.y = +1f;

        if (Input.GetKey(KeyCode.S))
            movement.y = -1f;

        if (Input.GetKey(KeyCode.A))
            movement.x = -1f;

        if (Input.GetKey(KeyCode.D))
            movement.x = +1f;
    }

    private void twistedControl()
    {

        if (Input.GetKey(KeyCode.A))
            movement.y = +1f;

        if (Input.GetKey(KeyCode.D))
            movement.y = -1f;

        if (Input.GetKey(KeyCode.W))
            movement.x = -1f;

        if (Input.GetKey(KeyCode.S))
            movement.x = +1f;
    }
}
