using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    //public BoxCollider2D bc;
    public Image item_image;
    bool item = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            item = !item;
        }

        if (item)
        {
            item_image.enabled = true;
        }
        else
        {
            item_image.enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                item = true;
            }
        }
    }
} 
