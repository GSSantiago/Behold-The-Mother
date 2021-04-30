//EXPLICAÇÃO MESH

/*Determina a posição de cada vértice,através de x,y, quanto maior a distancia
 * maior será o vertice formado
vertices[0] = Vector3.zero; //Definindo ponto na origem 0,0
vertices[1] = new Vector3(1, 0);
vertices[2] = new Vector3(0, -1);

//Determina a posição x,y da textura do poligono (geometria analitica)

uv[0]=0;
uv[1]=1;
uv[2]=2;

Triangles serve para fazer a conexão da forma, ou seja, cada
ponto está conectado com qual ponto, o movimento é horario

triangles[0] = 0;
triangles[1] = 1;
triangles[2] = 2;
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class EnemyFOV : MonoBehaviour
{
    [SerializeField] private LayerMask camada;
    [SerializeField] private EnemyPatrol enemy;
   // public Text contador;


    private Mesh malha;
    public float fov;
    private Vector3 origin;
    public float startingAngle;
    public float viewDistance = 20f;//Original 2f

    public bool isplayerFound;
    public bool isPerseguindo;



    // Start is called before the first frame update
    void Start()
    {
        malha = new Mesh(); //Criando o objeto mesh(malha) mas apenas na memoria
        GetComponent<MeshFilter>().mesh = malha;
        origin = Vector3.zero;
        fov = 90f; //Original 90f
        CallTime();

    }

    // Update is called once per frame
    #region FOV
    void LateUpdate()
    {

        int raycount = 50;
        float angle = startingAngle; //Original 0f
        float angleincrease = fov / raycount;


        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Parando corotinas");
            StopTime();
        }

        //contador.text = "Counter: " + counter;



        //Mesh precisa de tres variaveis
        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;



        //Essa função for está criando varios triangulos de acordo com o valor de raycount
        //a cada loop do for, um triangulo será criado, tomando ponto fixo, origem, e a partir dele
        //criando um triangulo
        for (int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, camada);
            if (raycastHit2D.collider == null)
            {
                //Nada hitou
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
                // Debug.Log("Nada hitou");

            }
            else
            {
                //Hitou 
                vertex = raycastHit2D.point;

                if (raycastHit2D.collider.gameObject.tag == "Player" && enemy.isInside)
                {
                    isplayerFound = true;
                    isPerseguindo = true;
                    //  Debug.Log("Player dentro da view");

                }
                else
                    if (!enemy.isInside)
                {
                    //Debug.Log("SEI LA");
                    isplayerFound = false;
                    // isPerseguindo = false;
                }



            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleincrease;
        }



        malha.vertices = vertices;
        malha.uv = uv;
        malha.triangles = triangles;


    }



    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(float aimDirection)
    {
        startingAngle = aimDirection;
    }
    #endregion



    #region setCoroutine
    public void CallTime()
    {
        StartCoroutine(Timer());
    }

    public void StopTime()
    {
        StopCoroutine(Timer());
    }

    #endregion

    #region counter
    int counter = 0;
    private IEnumerator Timer()
    {
        counter = 0;

        while (isPerseguindo)
        {
            // Debug.Log("To funcionando");
            yield return new WaitForSeconds(1);
            if (!isplayerFound)
            {
                counter++;
                // Debug.Log("Counter: " +counter);
                //Se o contador atingir 10 segundos,  o player escapou do monstro
                if (counter == 10)
                {
                    Debug.Log("Player fugiu do monstro");
                    isPerseguindo = false;
                    counter = 0;
                }
            }
            else
            {
                counter = 0;
                Debug.Log("O monstro continua tendo visão");
            }
        }

    }
    #endregion

}

