using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject : MonoBehaviour
{

   // private GameObject dialogObject;
    private CapsuleCollider2D collider;
    private PlayerMovement playerMovement;
    public GameObject dialogBox;

    public DialogManager dialogM;

    private bool inside;

    [SerializeField] Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {

        //dialogObject = this.gameObject.transform.GetChild(0).gameObject;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //dialogBox = GameObject.FindGameObjectWithTag("Dialog").GetComponent<GameObject>();
        dialogM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogManager>();
        collider = GetComponent<CapsuleCollider2D>();



    }

    private void Update()
    {
        if(inside && !dialogM.isFinished)
        {
           if (Input.GetKeyDown(KeyCode.E) && !dialogBox.activeSelf)
              DialogManager.Instance.ShowDialog(dialog);
            
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
