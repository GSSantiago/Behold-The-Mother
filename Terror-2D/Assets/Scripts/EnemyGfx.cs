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
    //[SerializeField] EnemyFovPosition position;

    private void Start()
    {
        InimigoIA = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIPath>();

    }

    void Update()
    {
        transform.position = Enemy.position;

        anim.SetFloat("Horizontal", InimigoIA.desiredVelocity.x);
        anim.SetFloat("Vertical", InimigoIA.desiredVelocity.y);

        //anim.SetFloat("Horizontal", position.direcaoX);
        //anim.SetFloat("Vertical", position.direcaoY);







    }
}
