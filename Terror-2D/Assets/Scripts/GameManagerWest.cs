using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWest : MonoBehaviour
{

    private Transform playerPos;
    private Transform cameraPos;
    private PauseScript objective;
    private Iscoming coming;

    public bool isWallFound = false;

    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        objective = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseScript>();

        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
        Iscoming();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPos.position = new Vector3(Mathf.Clamp(playerPos.position.x, -13.76f, 17.79f),
                                        Mathf.Clamp(playerPos.position.y, -6.889955f, 33.5f), -80f);

       
    }

    private void Iscoming()
    {
        if (coming.FromEntranceHall)
            playerPos.position = new Vector3(30.21414f, -0.2867637f, 0f);

       
    }
}
