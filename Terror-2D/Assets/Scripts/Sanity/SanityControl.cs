using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityControl : MonoBehaviour
{

    public GameObject CircleSanity;
    public Transform Player;
    public Transform enemy;
    public SanityScript sanity;
    public PlayerMovement PlayerMovement;
    [SerializeField] AudioManager audio;
    [SerializeField] AudioSource voices;
    public AudioSource ambience;


    private Scene scene;
    private string sceneName;


    int EfeitoRandom;

    [HideInInspector] public bool isSanityLow75 = true;
    [HideInInspector] public bool isSanityLow50 = true;
    [HideInInspector] public bool isSanityLow25 = true;

    [SerializeField] Dialog dialog;


    private void OnLevelWasLoaded(int level)
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        //Getcomponent
        CircleSanity = GameObject.Find("/IA/CircleSanity");
        dialogBox = GameObject.Find("/Player/Canvas/DialogBox");
        dialogText = GameObject.Find("/Player/Canvas/DialogBox/Text").GetComponent<Text>();


        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();

    }

    void Start()
    {
      
    }


    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            //5 É uma distancia boa
            if (sceneName == "West Wing")
            {

                if (Vector3.Distance(Player.position, enemy.position) > 5)
                    CircleSanity.SetActive(false);
                else
                    CircleSanity.SetActive(true);

            }
        }

          

            if (sanity.sanity_value < 75 && isSanityLow75)
            {
                StartCoroutine(voicesSound());
                ambience.pitch = 1.1f;
                isSanityLow75 = false;
            }

            if (sanity.sanity_value < 50 && isSanityLow50)
            {
                StartCoroutine(creppyvoices());
                isSanityLow50 = false;
            }
            if (sanity.sanity_value < 25 && isSanityLow25)
            {
                StartCoroutine(Insanephrases());
                isSanityLow25 = false;
            }

 
    }

    IEnumerator voicesSound()
    {
        float i;
        voices.Play();
        while (sanity.sanity_value < 75)
        {
            for (i = voices.panStereo; i < 1; i += 0.02f)
            {
                voices.panStereo = i;
                yield return new WaitForSeconds(0);

            }

            for (i = voices.panStereo; i > -1; i -= 0.02f)
            {
                voices.panStereo = i;
                yield return new WaitForSeconds(0);

            }
        }
    }

    //Random range funciona com o primeira numero é incluido e o ultimo não
    //Por exemplo, Random.Range(0,6), será randomizados numeros entre 0 a 5
    IEnumerator creppyvoices()
    {
        int i;
        int somRandom = 0;
        int randomPan = 0;



        while (sanity.sanity_value < 50)
        {
            if (!audio.isPlaying(somRandom))
            {
                do
                {
                    randomPan = Random.Range(-1, 2);
                } while (randomPan == 0);


                somRandom = Random.Range(0, 5);
                audio.Volume(somRandom, 0.4f);
                audio.Play(somRandom);
                audio.stereoPan(somRandom, randomPan);

                yield return new WaitForSeconds(20);
                randomPan = 0;
            }
            yield return null;
        }
        audio.Stop(somRandom);

    }


    IEnumerator Insanephrases()
    {
        while(sanity.sanity_value < 25)
        {
            ShowDialog(dialog);
            yield return new WaitForSeconds(5f);

        }
        yield return null;
    }

    public void allNormal()
    {
        EfeitoRandom = 0;
        PlayerMovement.changeControl = false;

        voices.Stop();
    }

    [Header("Dialog Manager")]
    #region DialogSanity

    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    // [SerializeField] PlayerMovement playerMovement;


    [SerializeField] int lettersPerSecond;
    // public Animator anim;


    int currentLine = 0;
    bool isTyping;
    public bool isFinished;

    private void ShowDialog(Dialog dialog)
    {
        this.dialog = dialog;
        dialogBox.SetActive(true);

        StartCoroutine(TypeDialog(dialog.Lines[Random.Range(0, 4)]));
    }

    private IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        //  anim.SetBool("Istalking", true);
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        yield return new WaitForSeconds(2f);

        isTyping = false;
        dialogBox.SetActive(false);
        isFinished = true;
        // anim.SetBool("Istalking", false);

    }
    #endregion
}
