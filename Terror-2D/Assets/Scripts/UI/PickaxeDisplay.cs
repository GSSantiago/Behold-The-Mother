using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickaxeDisplay : MonoBehaviour
{
    //public BoxCollider2D bc;
    public Image item_image;
    bool item = false;


    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                item_image.enabled = true;
            }
        }
    }
}
