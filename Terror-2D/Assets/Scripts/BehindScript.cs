using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BehindScript : MonoBehaviour
{
    public Tilemap tmap;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           tmap.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            tmap.color = new Color(1f, 1f, 1f, 1f);
        }
    }

}
