using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMUpperWestWing : MonoBehaviour
{

    private Transform playerPos;
    private Transform cameraPos;
    private PauseScript objective;
    private Iscoming coming;

    private bool isRightPos = false;


    // Start is called before the first frame update
    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        objective = GameObject.FindGameObjectWithTag("UI").GetComponent<PauseScript>();

        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();


    }
    private void OnLevelWasLoaded(int level)
    {
        Iscoming();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
        if (!isRightPos)
            Iscoming();

        cameraPos.position = new Vector3(Mathf.Clamp(playerPos.position.x, -13.76f, 17.79f),
                                        Mathf.Clamp(playerPos.position.y, -6.889955f, 33.5f), -80f);


    }

    private void Iscoming()
    {
        if (coming.FromMasterStudyUp)
            playerPos.position = new Vector3(29.36947f, 32.84718f, -1f);
        isRightPos = true;


    }
}
