using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerMasterStudy : MonoBehaviour
{
    public Iscoming coming;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();

    }

    public void FirstCutsceneEnds()
    {
        coming.isFirstcutscenePlayed = true;
    }
}
