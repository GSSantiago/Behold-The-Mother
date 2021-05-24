
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFovPosition : MonoBehaviour
{
    [SerializeField] private EnemyFOV fov;
    [SerializeField] private EnemyFOVSanity CircleSanity;

    float posAnteriorX;
    float posAnteriorY;
    public float direcaoX;
    public float direcaoY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("posicaoAnterior", 0f, 1f);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        fov.setOrigin(transform.position);
        CircleSanity.setOrigin(transform.position);

        direcaoX = Mathf.Round(transform.position.x - posAnteriorX);
        direcaoY = Mathf.Round(transform.position.y - posAnteriorY);
        if (direcaoX > 0)
        {
            //Direita
            fov.SetAimDirection(45f);
        }
        if (direcaoX < 0)
        {
            //Esquerda
            fov.SetAimDirection(225f);
        }

        if (direcaoY > 0 && direcaoX == 0)
        {
            //Cima
            fov.SetAimDirection(135f);
        }

        if (direcaoY < 0 && direcaoX == 0)
        {
            //Baixo
            fov.SetAimDirection(315f);
        }

        if ((direcaoX > 0 && direcaoX != 0) && direcaoY > 0)
        {
            //Diagonal cima direita
            fov.SetAimDirection(90f);
        }

        if ((direcaoX < 0 && direcaoX != 0) && direcaoY > 0)
        {
            //Diagonal cima esquerda
            fov.SetAimDirection(180f);
        }

        if ((direcaoX < -2 && direcaoX != 0) && direcaoY < 0)
        {
            //Diagonal baixo esquerda
            fov.SetAimDirection(270f);
        }

        if ((direcaoX > -2 && direcaoX != 0) && direcaoY < 0)
        {
            //Diagonal baixo direita
            fov.SetAimDirection(360f);
        }


    }

    void posicaoAnterior()
    {
        posAnteriorX = transform.position.x;
        posAnteriorY = transform.position.y;
    }
}
