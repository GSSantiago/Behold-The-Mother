using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CandleScript : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    public Light2D luz;

    //mode = 0 - apagada -- mode = 1 - acesa
    public int mode = 0;

    void Awake()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        luz.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == 0)
        {
            luz.intensity = 0;
        }

        if(mode == 1)
        {
            luz.intensity = 1;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                if (mode == 0)
                {
                    mode = 1;
                }
                else
                {
                    mode = 0;
                }
            }
        }
    }
}
