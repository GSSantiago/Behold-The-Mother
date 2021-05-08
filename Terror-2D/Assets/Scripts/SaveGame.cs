using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Collider2D collider;
    public SanityScript sanity;

    public GameObject dialogBox;
    public DialogManager dialogM;

    [SerializeField] Dialog dialog;

    private bool inside;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        sanity = GameObject.FindGameObjectWithTag("Sanity").GetComponent<SanityScript>();

        //dialogBox = GameObject.FindGameObjectWithTag("Dialog").GetComponent<GameObject>();
        dialogM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inside && !dialogM.isFinished)
        {
            if (Input.GetKeyDown(KeyCode.E) && !dialogBox.activeSelf)
            {
                DialogManager.Instance.ShowDialog(dialog);
                sanity.sanity_value = 100;
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
    }


}
