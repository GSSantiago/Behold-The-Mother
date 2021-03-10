using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private EnemyFOV fov;
    [SerializeField] private Transform player;
    [SerializeField] private EnemyFovPosition EnemyPosition;


    public Transform[] points;
    public Path p;
    public AIPath InimigoIA;
 
    
    Seeker seeker;

    //DECLARAÇÃO DE VARIAVEIS
    bool isRandomfinish;
    bool isMoving;
  

    //Inicialização de lista
    List<int> ways = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();

        GerarRandom();//Gera uma lista de waypoints random

        StartCoroutine(estaMovendo());
        
        seeker.StartPath(transform.position, points[ways[0]].position);

    }



    // Update is called once per frame
    void Update()
    {
       

    }

    public void perseguir()
    {
        seeker.StartPath(transform.position, player.position);

    }


    #region Patrulha
    int indexWay=0;
   public void patrulha()
    {
            if (InimigoIA.reachedEndOfPath && !isMoving)
            {
                seeker.StartPath(transform.position, points[ways[indexWay]].position);
                //Debug.Log("O way atual é:" + points[ways[indexWay]]);
                indexWay++;

                if (indexWay == 5)
                {

                    GerarRandom();
                    indexWay = 0;
                }
            }

           
        
    }


    //Declaração de variavel para função abaixo

    void GerarRandom()
    {
        int randomico;
        isRandomfinish = true;
        ways.Clear();
        while (isRandomfinish)
        {
            Debug.Log("Estou no gerando lista");

            randomico = Random.Range(0, 6);

            if (!ways.Contains(randomico))
                ways.Add(randomico);

            if (ways.Count == 5)
                isRandomfinish = false;
        }
        
    }


    #endregion

    #region Coroutines
    IEnumerator estaMovendo()
    {
        while (true)
        {
            if (EnemyPosition.direcaoX == 0f && EnemyPosition.direcaoY == 0f)
                isMoving = false;
            else
                isMoving = true;
            yield return null;
        }

    }

    #endregion
}

