using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private Collider2D interactionArea;
    private Collider2D collision;
    private GameObject myGlowClosed;
    private GameObject myGlowOpen;
    private Animator myAnim;
    private SpriteRenderer mySROpen;
    private SpriteRenderer mySRClosed;

    private AudioSource myAS;
    public AudioClip acOpen;
    public AudioClip acClose;

    private bool inside;
    private bool open;

    public int time;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        myGlowClosed = this.gameObject.transform.GetChild(0).gameObject;
        myAnim = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
        myGlowOpen = this.gameObject.transform.GetChild(2).gameObject;

        myAS = GetComponent<AudioSource>();
        interactionArea = GetComponent<Collider2D>();
        collision = myGlowClosed.GetComponent<Collider2D>();
        mySROpen = myGlowOpen.GetComponent<SpriteRenderer>();
        mySRClosed = myGlowClosed.GetComponent<SpriteRenderer>();

        collision.enabled = true;

        mySRClosed.enabled = false;
        mySROpen.enabled = false;
        inside = false;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (t < 1000)
            t += 60 * Time.deltaTime;
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.E) && t > 105)
            {

                t = 0;
                myAnim.SetBool("Interagido", true);
                mySRClosed.enabled = !mySRClosed.enabled;
                mySROpen.enabled = !mySROpen.enabled;
                open = !open;
                myAS.pitch = Random.Range(1f, 3f);
                if (open)
                {
                    myAS.PlayOneShot(acOpen, Random.Range(0.8f, 1f));
                }
                else
                {
                    myAS.PlayOneShot(acClose, Random.Range(0.8f, 1f));
                }
            }
            else if (t > 105)
            {
                myAnim.SetBool("Interagido", false);
                mySRClosed.enabled = !open;
                mySROpen.enabled = open;
            }
        }
        else
        {
            mySRClosed.enabled = false;
            mySROpen.enabled = false;
        }
        collision.enabled = !open;

        ChangeLayer();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            inside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            inside = false;
        }

    }

    public void ChangeLayer()
    {
        if (open == true)
            gameObject.layer = 0;

        if (open == false)
            gameObject.layer = 11;
    }
}
