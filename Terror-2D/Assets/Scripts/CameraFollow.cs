using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;

      
    void LateUpdate () 
    {
        // transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, -80f); // Camera follows the player with specified offset position
        /*transform.position = new Vector3(Mathf.Clamp(player.position.x, -18.5f, 22.5f),
                                         Mathf.Clamp(player.position.y, -8.8f, 33.5f), -80f);*/
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -13.1f, 17.5f),
                                         Mathf.Clamp(player.position.y, -6.4f, 32.3f), -80f);
        
    }
}
