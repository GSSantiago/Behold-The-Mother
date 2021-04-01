﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;
    public SanityScript sanity;
      
    void LateUpdate () 
    {
        // transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, -80f); // Camera follows the player with specified offset position
        /*transform.position = new Vector3(Mathf.Clamp(player.position.x, -18.5f, 22.5f),
                                         Mathf.Clamp(player.position.y, -8.8f, 33.5f), -80f);*/
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -13.1f, 17.5f),
                                         Mathf.Clamp(player.position.y, -6.4f, 32.3f), -80f);
        Debug.Log(sanity.sanity_value);
        Debug.Log("teste");
        if(sanity.sanity_value > 0.5)
        {
            StartCoroutine(shake());
        }
    }
    public IEnumerator shake()
    {
        int i = 0;
        Vector3 pos = transform.position;

        for (i = 0; i < 100; i++)
        {
            float dist = Random.Range(-0.1f, 0.1f);
            float x = dist;
            float y = dist;
            transform.position = new Vector3(pos.x + x, pos.y + y, pos.z);
            yield return new WaitForSeconds(0.01f);
        }

    }
}
