using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Collider2D collider;

    public SanityScript sanity;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        sanity = GameObject.FindGameObjectWithTag("Sanity").GetComponent<SanityScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            sanity.sanity_value = 100;
        }
    }

    
}
