using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWest : MonoBehaviour
{

    private Transform playerPos;
    private Transform cameraPos;
    private PauseScript objective;

    private bool isWallFound = false;

    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        objective = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseScript>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPos.position = new Vector3(Mathf.Clamp(playerPos.position.x, -18.5f, 22.5f),
                                        Mathf.Clamp(playerPos.position.y, -8.8f, 33.5f), -80f);

        if (Input.GetKeyDown(KeyCode.M)&&!isWallFound)
        {
            objective.ObjetivoAtual++;
            isWallFound = true;
        }
    }
}
