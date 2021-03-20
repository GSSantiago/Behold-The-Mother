using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BehindScript : MonoBehaviour
{
    public Light2D luz;
    public BoxCollider2D coll;

    void Start()
    {
        luz.shadowIntensity = 1;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "baseParede")
        {
            luz.shadowIntensity = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "baseParede")
        {
            luz.shadowIntensity = 1;
        }
    }

}
