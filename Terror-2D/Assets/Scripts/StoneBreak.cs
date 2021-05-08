using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoneBreak : MonoBehaviour
{

    // private GameObject dialogObject;
    private Collider2D collider;
    private PlayerMovement playerMovement;
    public GameObject dialogBox;

    public DialogManager dialogM;

    public GameManagerWest GMW;

    [SerializeField] Iscoming objetivo;
    [SerializeField] AudioSource stone;


    [SerializeField] GameObject transition;


    private bool inside;
    private bool IsFinishedDialogWall;

    [SerializeField] Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {

        //dialogObject = this.gameObject.transform.GetChild(0).gameObject;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //dialogBox = GameObject.FindGameObjectWithTag("Dialog").GetComponent<GameObject>();
        dialogM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogManager>();
        collider = GetComponent<Collider2D>();
        objetivo = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();



    }

   private void Update()
   {
     if (inside && !dialogM.isFinished)
        {
            if (Input.GetKeyDown(KeyCode.E) && !dialogBox.activeSelf)
             {
                if (!objetivo.ispickaxePicked)
                   {
                     DialogManager.Instance.ShowDialog(dialog);
                            IsFinishedDialogWall = true;
                   }
                else
                   {
                    StartCoroutine(Break());
                    stone.Play();
                    Debug.Log("To aqui");

                    }
             }
         }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
            inside = true;


    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
            inside = false;

        if (IsFinishedDialogWall && collider.gameObject.tag == "Player" && !objetivo.ispickaxePicked)
            objetivo.Objective++;
           
    }
    IEnumerator Break()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(2f);
        stone.Stop();
        transition.SetActive(false);
        Destroy(gameObject);


    }


}
