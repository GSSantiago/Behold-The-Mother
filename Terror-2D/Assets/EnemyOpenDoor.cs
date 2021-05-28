using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpenDoor : MonoBehaviour
{
    public bool inside;
    public Porta porta;
    private Transform portaPos;
    private EnemyPatrol enemy;
    private Transform enemyPos;

    public bool isChecking;
    public bool isChasing;

    // Start is called before the first frame update
    void Start()
    {
        porta = gameObject.GetComponentInParent<Porta>();
        portaPos = gameObject.GetComponentInParent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyPatrol>();
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    bool isStarted = true;
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            inside = true;
            StartCoroutine(OpenDoor());
        }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            inside = false;
            StopCoroutine(OpenDoor());
        }

    }

    IEnumerator OpenDoor()
    {
        Debug.Log("Iniciada coroutine");

        while (inside)
        {
            Debug.Log("Inimigo pode abrir a porta");
            if (porta.enemyInside&&(isChasing||isChecking))//Se o inimigo estiver dentro da area e estiver perseguindo
            {
                Debug.Log("Inimigo vai abrir a porta");
                enemy.isOpen = true;//Bool irá avisar que o inimigo irá abrir a porta
                enemy.seeker.StartPath(enemyPos.position, portaPos.position);//O inimigo começará a fitar a porta
                yield return new WaitForSeconds(2f);//Espera 2 seg
                porta.OpenDoor();//porta abre
                enemy.isOpen = false;
                yield break;
            }

            yield return null;
        }
        yield return null;
    }

}
