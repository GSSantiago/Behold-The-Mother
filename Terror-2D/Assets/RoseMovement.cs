using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseMovement : MonoBehaviour
{

    private float moveSpeed = 5f;
    public float normalSpeed = 5f;
    public float runSpeed = 8f;
    public Animator anim;
    public bool isRunning;

    public Vector2 moveDir;
    public Vector2 movement;

    public Transform player;
    public PlayerMovement playerMove;
    [SerializeField] SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Ismove", false);
    }

    // Update is called once per frame
    void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, player.position);
        if(distancePlayer <= 2)
        {
            anim.SetFloat("Horizontal", (player.transform.position.x - transform.position.x));
            anim.SetFloat("Vertical", (player.transform.position.y - transform.position.y));

            anim.SetBool("Ismove", false);
            anim.SetBool("Isrun", false);

            if ((player.transform.position.y - transform.position.y) > 0)
                sprite.sortingOrder = 6;
            else
                sprite.sortingOrder = 4;
        }
        else
        {
            if (playerMove.isIdle)
            {
                anim.SetBool("Ismove", false);
                anim.SetBool("Isrun", false);
            }
            anim.SetBool("Ismove", true);

            anim.SetFloat("Horizontal", (player.transform.position.x - transform.position.x));
            anim.SetFloat("Vertical", (player.transform.position.y - transform.position.y));

             transform.position = Vector2.MoveTowards(transform.position, player.position, normalSpeed * Time.deltaTime);
        }
    }
}
