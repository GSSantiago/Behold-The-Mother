using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    public CapsuleCollider2D Ccollider;
    public Image item_image;
    public bool item = false;

    [SerializeField] Iscoming objetivo;
    [SerializeField] AudioSource Keypicked;


    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerStay2D(Collider2D Ccollider)
    {
        if (Ccollider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Pick());  
            }
        }
    }

    IEnumerator Pick()
    {
        Keypicked.Play();
        objetivo = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
        objetivo.isKeyPicked = true;
        objetivo.Objective++;
        objetivo.KeyDisplay = true;
        yield return new WaitForSeconds(0.20f);
        Destroy(gameObject);


    }
}
