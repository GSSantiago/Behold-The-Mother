using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour
{
    public CapsuleCollider2D Ccollider;
    public Image item_image;
    public bool item = false;


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

    void OnTriggerStay2D(Collider2D Ccollider)
    {
        if (Ccollider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Oi");
                item = true;
            }
        }
    }
}
