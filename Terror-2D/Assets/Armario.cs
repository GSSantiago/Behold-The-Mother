using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : MonoBehaviour
{
    private Collider2D interactionArea;
    private Collider2D collision;
    private GameObject myGlowClosed;
    private GameObject myGlowOpen;
    private Animator myAnim;
    private SpriteRenderer mySROpen;
    private SpriteRenderer mySRClosed;

    private Collider2D playerCollider;
    private SpriteRenderer playerSprite;
    private PlayerMovement playerMovement;
    private Flashlight flashlight;
    private EnemyFOV enemyfov;


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

        //Getcomponent do player

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        flashlight = GameObject.FindGameObjectWithTag("Light").GetComponent<Flashlight>();
        enemyfov = GameObject.FindGameObjectWithTag("FOV").GetComponent<EnemyFOV>();

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
            if (Input.GetKeyDown(KeyCode.E) && t > 35)
            {
                t = 0;
                myAnim.SetBool("Interagido", true);
                mySRClosed.enabled = !mySRClosed;
                mySROpen.enabled = !mySROpen;
                open = !open;
                myAS.pitch = Random.Range(1f, 3f);           
                if (open)
                {
                    myAS.PlayOneShot(acOpen, Random.Range(0.8f, 1f));
                    StartCoroutine(Hiding());
                }
                else
                {
                    myAS.PlayOneShot(acClose, Random.Range(0.8f, 1f));
                    StartCoroutine(Unhiding());
                }
            }
            else if (t > 30)
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

    IEnumerator Hiding()
    {
        float opacidade=1f;

        while (opacidade > -1f)
        {
           opacidade -= 0.05f;
           playerSprite.color = new Color(1f, 1f, 1f, opacidade);
           yield return new WaitForSeconds(3 / 10);
        }
        //Desabilitando componentes do player para se manter escondido
        //playerCollider.enabled = false;
        playerMovement.enabled = false;
        flashlight.enabled = false;
        enemyfov.viewDistance = 0;
    }
    IEnumerator Unhiding()
    {
        float opacidade = 0f;

        while (opacidade <= 1f)
        {
            opacidade += 0.01f;//0.05
            playerSprite.color = new Color(1f, 1f, 1f, opacidade);
            yield return new WaitForSeconds(3 / 10);
        }
        //Habilitando componentes do player para sair do esconderijo
        //playerCollider.enabled = true;
        playerMovement.enabled = true;
        flashlight.enabled = true;
        enemyfov.viewDistance = 20;

    }



}
