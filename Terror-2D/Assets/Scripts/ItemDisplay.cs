﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public BoxCollider2D bc;
    public Image item_image;
    bool TakeItem = false;
    

    // Update is called once per frame
    void Update()
    {
        if (TakeItem)
        {
            item_image.enabled = true;
        }
        else
        {
            item_image.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        if(collision.gameObject.tag == "Player")
        {
            TakeItem = true;
        }    
    }
}
