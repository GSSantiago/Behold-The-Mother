using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoWestWing : MonoBehaviour
{
<<<<<<< HEAD
    //AsyncOperation asyncOperation;
    public Animator transition;
=======
    AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());

    }

    // Update is called once per frame
    void Update()
    {

    }
>>>>>>> parent of 8e915af (Hall Update)

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD
            StartCoroutine(LoadYourAsyncScene());
            //asyncOperation.allowSceneActivation = true;
=======
            asyncOperation.allowSceneActivation = true;
>>>>>>> parent of 8e915af (Hall Update)
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

<<<<<<< HEAD
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("West Wing");

        /*asyncOperation = SceneManager.LoadSceneAsync("West Wing");
        asyncOperation.allowSceneActivation = false;*/

        // Wait until the asynchronous scene fully loads
        /*while (!asyncOperation.isDone)
        {

            yield return null;
        }*/
=======
        asyncOperation = SceneManager.LoadSceneAsync("West Wing");
        asyncOperation.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncOperation.isDone)
        {

            yield return null;
        }
>>>>>>> parent of 8e915af (Hall Update)
    }
}