﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoHall : MonoBehaviour
{
    public Animator transition;
    public BoxCollider2D bc;

    private Iscoming coming;
    private Scene scene;

    private void Start()
    {
        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Scene());
            if(scene.name == "East Wing")
                coming.fromEastWing();

            if (scene.name == "West Wing")
                coming.fromWestWing();

        }

    }

    IEnumerator Scene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Entrance Hall");
    }

}
