﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Iscoming : MonoBehaviour
{

    public bool FromEntranceHall=false;
    public bool FromWestWing=false;
    public bool FromEastWing=false;

    public bool ispickaxePicked = false;
    public bool isKeyPicked = false;
    public int Objective;

    public bool PickaxeDisplay = false;
    public bool KeyDisplay = false;

    [SerializeField] PauseScript pause;
    [SerializeField] Image key;
    [SerializeField] Image pickaxe;

    private Scene scene;
    private string sceneName;
    private AudioSource ambienceSound;


    // Start is called before the first frame update

    private void OnLevelWasLoaded(int level)
    {
        pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseScript>();
        key = GameObject.FindGameObjectWithTag("Key").GetComponent<Image>();
        pickaxe = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<Image>();
        ambienceSound = GetComponent<AudioSource>();

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "Entrance Hall" && !ambienceSound.isPlaying)
            ambienceSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (pause != null) { pause.ObjetivoAtual = Objective; }
        if (key != null) { key.enabled = KeyDisplay; }
        if (pickaxe != null) { pickaxe.enabled = PickaxeDisplay; }

    }

    void iscoming()
    {
     
    }

    public void fromEntranceHall()
    {
        FromEntranceHall = true;
        FromWestWing = false;
        FromEastWing = false;
        
    }

    public void fromWestWing()
    {
        FromEntranceHall = false;
        FromWestWing = true;
        FromEastWing = false;
    }

    public void fromEastWing()
    {
        FromEntranceHall = false;
        FromWestWing = false;
        FromEastWing = true;
    }
}