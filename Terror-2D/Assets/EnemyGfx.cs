using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGfx : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Enemy;
    //[SerializeField] AILerp InimigoIA;
    [SerializeField] Animator anim;
    [SerializeField] EnemyFovPosition position;

    private void Start()
    {
        position = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFovPosition>();

    }

    void Update()
    {
        transform.position = Enemy.position;

       // anim.SetFloat("Horizontal", InimigoIA.desiredVelocity.x);
        //anim.SetFloat("Vertical", InimigoIA.desiredVelocity.y);

        anim.SetFloat("Horizontal", position.direcaoX);
        anim.SetFloat("Vertical", position.direcaoY);







    }
}
