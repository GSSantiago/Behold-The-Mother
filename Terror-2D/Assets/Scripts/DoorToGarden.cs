using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToGarden : MonoBehaviour
{
    // private GameObject dialogObject;
    private CapsuleCollider2D collider;
    private PlayerMovement playerMovement;
    public GameObject dialogBox;

    public DialogManager dialogM;

    private bool inside;

    [SerializeField] Dialog dialog;
    [SerializeField] Iscoming Manager;

    // Start is called before the first frame update
    private void OnLevelWasLoaded(int level)
    {
        Manager = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
        //dialogObject = this.gameObject.transform.GetChild(0).gameObject;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //dialogBox = GameObject.FindGameObjectWithTag("Dialog").GetComponent<GameObject>();
        dialogM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogManager>();
        collider = GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {

    }

    private void Update()
    {
        if (inside && !dialogM.isFinished)
        {    
           if (Input.GetKeyDown(KeyCode.E) && !dialogBox.activeSelf)
               if(!Manager.KeyDisplay)
                  DialogManager.Instance.ShowDialog(dialog);
               else
                  SceneManager.LoadScene("MenuPrincipal");
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
    }


}
