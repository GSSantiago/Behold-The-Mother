using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpider : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
      
    void Update () 
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, -80f); // Camera follows the player with specified offset position
    }
}
