using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject : MonoBehaviour
{

    private GameObject dialogObject;
    private Collider2D collider;
    private PlayerMovement playerMovement;


    [SerializeField] Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {

        dialogObject = this.gameObject.transform.GetChild(0).gameObject;

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        collider = GetComponent<Collider2D>();

    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
         if (Input.GetKeyDown(KeyCode.E))
            DialogManager.Instance.ShowDialog(dialog);
        }
    }
}
