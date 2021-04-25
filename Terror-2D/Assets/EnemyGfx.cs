using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGfx : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Enemy;
    [SerializeField] AIPath InimigoIA;
    [SerializeField] Animator anim;

    void Update()
    {
        transform.position = Enemy.position;

        anim.SetFloat("Horizontal", InimigoIA.desiredVelocity.x);
        anim.SetFloat("Vertical", InimigoIA.desiredVelocity.y);




    }
}
