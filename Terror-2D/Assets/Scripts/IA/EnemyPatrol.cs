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
    //public AILerp InimigoIA;
    public AstarPath astar;
    public AudioSource PerseguicaoSom;


    Seeker seeker;
    //DECLARAÇÃO DE VARIAVEIS
    bool isRandomfinish;
    bool isMoving;
    public bool isInside = false;

    //Inicialização de lista
    List<int> ways = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        PerseguicaoSom = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();


        GerarRandom();//Gera uma lista de waypoints random

        StartCoroutine(estaMovendo());

        seeker.StartPath(transform.position, points[ways[0]].position);


    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }

    public void perseguir()
    {
        seeker.StartPath(transform.position, player.position);

    }

    public void scan()
    {
        astar.Scan();
    }


    #region Patrulha
    int indexWay = 0;
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

    public void DiminuirVolume()
    {
        StartCoroutine(diminuirVolume());
    }

    IEnumerator diminuirVolume()
    {
        for(float i =1;i!=0;i-=0.1f)
        {
            PerseguicaoSom.volume = i;
            yield return new WaitForSeconds(1f);
        }
               

    }

    #endregion


}

