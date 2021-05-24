using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoWestWing : MonoBehaviour
{
    public Animator transition;
    public BoxCollider2D bc;
    private Iscoming coming;

    private void Start()
    {
        coming = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Scene());
            coming.fromEntranceHall();

        }

    }

    IEnumerator Scene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("West Wing");
    }
}
