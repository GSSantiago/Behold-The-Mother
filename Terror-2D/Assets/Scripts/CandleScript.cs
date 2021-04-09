using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CandleScript : MonoBehaviour
{
    private CircleCollider2D coll;
    private Rigidbody2D rb;
    public Light2D luz;
    public GameObject fire_particle;
    public GameObject smoke_particle;
    
    public bool mode = false;

    void Awake()
    {
        coll = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        luz.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == false)
        {
            fire_particle.SetActive(false);
            smoke_particle.SetActive(false);
            luz.intensity = 0;
        }

        if(mode == true)
        {
            fire_particle.SetActive(true);
            smoke_particle.SetActive(true);
            luz.intensity = 1;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                if (mode == false)
                {
                    mode = true;
                }
                else
                {
                    mode = false;
                }
            }
        }
    }
}
