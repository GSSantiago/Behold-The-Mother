using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxePick : MonoBehaviour
{

    private bool inside;
    private bool IspickaxePicked;

    [SerializeField] SpriteRenderer srl;
    [SerializeField] AudioSource pick;
    [SerializeField] Iscoming pickaxe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {
        pickaxe = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();

    }
    // Update is called once per frame
    void Update()
    {

        if (inside && !IspickaxePicked && pickaxe.Objective==1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IspickaxePicked = true;
                pickaxe.ispickaxePicked = true;
                srl.sortingOrder = 4;
                pickaxe.PickaxeDisplay = true;
                pick.Play();

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inside = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inside = false;
    }
}
