using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWest : MonoBehaviour
{

    private Transform playerPos;
    private Transform cameraPos;
    private PauseScript objective;
    public Iscoming coming;
    private bool isRightPos = false;
    //public bool isWallFound = false;
    public GameObject Enemy;
    public GameObject EnemyIa;
    public GameObject TimelineFinal;

    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject RoseBlack;

    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        objective = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseScript>();

        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();


    }

   


    // Update is called once per frame
    void LateUpdate()
    {
        cutscene = GameObject.Find("TimelineManager");
        RoseBlack = GameObject.Find("RoseBlack");
        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();

        if (!isRightPos)
            Iscoming();

        if (flag)
        {
            if (coming.isFirstcutscenePlayed)
            {
                Destroy(cutscene);
                Destroy(RoseBlack);
                Enemy.SetActive(true);
                TimelineFinal.SetActive(true);
                if (coming.isLastcutscenePlayed)
                {
                    Destroy(TimelineFinal);
                    EnemyIa.SetActive(true);
                }
            }
            flag = false;
        }
        


        cameraPos.position = new Vector3(Mathf.Clamp(playerPos.position.x, -13.76f, 17.79f),
                                        Mathf.Clamp(playerPos.position.y, -6.889955f, 33.5f), -80f);

       
    }

    public void LastCustcenePlayed()
    {
        coming.isLastcutscenePlayed = true;
    }

    private void Iscoming()
    {
        if (coming.FromEntranceHall)
            playerPos.position = new Vector3(30.21414f, -0.2867637f, 0f);

        if(coming.FromUpperWestWing)
        {
            Debug.Log("funciona");
            playerPos.position = new Vector3(-19.31272f, 20.14832f, 0f);

        }
        isRightPos = true;

    }
}
