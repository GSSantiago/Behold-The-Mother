using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerHall : MonoBehaviour
{
    AsyncOperation asyncOperation;
    private Transform playerPos;
    private Transform cameraPos;
    public bool isgameStarted;

    [SerializeField] ObjeticveList objetivoLista;
    [SerializeField] Text ObjectiveText;
    public int ObjetivoAtual=0;
    


    // Start is called before the first frame update
    void Start()
    {
        //Coroutine para troca de cena
       // StartCoroutine(LoadYourAsyncScene());

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        //Caso o modo jogo esteja ativado
        GameStart();
            

    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPos.position = new Vector3(Mathf.Clamp(playerPos.position.x, -7f, 7f),
                                        Mathf.Clamp(playerPos.position.y, -3.7f, 36.4f), -80f);
    }

    #region Troca de cena
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            asyncOperation.allowSceneActivation = true;
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        asyncOperation = SceneManager.LoadSceneAsync("West Wing");
        asyncOperation.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncOperation.isDone)
        {

            yield return null;
        }
    }
    #endregion

    void GameStart()
    {
        if (isgameStarted)
        {
            playerPos.position = new Vector3(-0.03f, -8.61f, 0f);


        }
    }

    public void objetivos()
    {
        ObjectiveText.text = objetivoLista.Lines[ObjetivoAtual];
    }
}