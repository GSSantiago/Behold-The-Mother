using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SanityControl : MonoBehaviour
{

    public GameObject CircleSanity;
    public Transform Player;
    public Transform enemy;
    public SanityScript sanity;
    public PlayerMovement PlayerMovement;
    //public PixelPerfectCamera pixelCamera;
    // public Camera camera;
    // public Transform CameraZ;
    [SerializeField] AudioSource voices;

    private Scene scene;
    private string sceneName;

    int EfeitoRandom;
    public bool isSanityLow = true;
    //bool crazy;
    // bool inverted;

    private void OnLevelWasLoaded(int level)
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        //Getcomponent
        CircleSanity = GameObject.Find("/IA/CircleSanity");

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        // camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //  CameraZ = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();


        //StartCoroutine(efeitos());
        //  StartCoroutine(crazyCamera());
        // StartCoroutine(InvertedCamera());
    }

    void Start()
    {
        /*StartCoroutine(efeitos());
        StartCoroutine(crazyCamera());
        StartCoroutine(InvertedCamera());*/
    }


    // Update is called once per frame
    void Update()
    {

        //5 É uma distancia boa
        if (sceneName == "West Wing")
        {

            if (Vector3.Distance(Player.position, enemy.position) > 5)
                CircleSanity.SetActive(false);
            else
                CircleSanity.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Y))
            {
                EfeitoRandom = 2;
                Debug.Log("Efeito é" + EfeitoRandom);
            }
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(voicesSound());
        }

        if (sanity.sanity_value < 75 && isSanityLow)
        {
            Debug.Log("Quantas vezes entrei aqui:");
            StartCoroutine(efeitos());
            isSanityLow = false;
        }


    }

   

    IEnumerator efeitos()
    {
        //  EfeitoRandom = Random.Range(1, 2);
        EfeitoRandom = 2;
        Debug.Log("O Efeito é o: " + EfeitoRandom);

        switch (EfeitoRandom)
        {
            case 1:
                twistedControl();
                break;

            case 2:
                StartCoroutine(voicesSound());
                break;
        }



        yield return null;
    }


    void twistedControl()
    {
        PlayerMovement.changeControl = true;
    }

    public float timeCounter;//antes tava 1f

    IEnumerator voicesSound()
    {
        float i;
        voices.Play();
        while (sanity.sanity_value < 75)
        {
            for (i = voices.panStereo; i < 1; i += 0.02f)
            {
                voices.panStereo = i;
                yield return new WaitForSeconds(timeCounter / 10);

            }

            for (i = voices.panStereo; i > -1; i -= 0.02f)
            {
                voices.panStereo = i;
                yield return new WaitForSeconds(timeCounter / 10);

            }
        }
    }

    #region crazyCamera
    int CameraRandom;

    /* IEnumerator crazyCamera()
     {
         while (true)
         {
             float i;

             if (crazy == true)
             {
                 CameraRandom = Random.Range(8, 10);
                 for (i = camera.orthographicSize; i < CameraRandom; i += 1f)
                 {
                     camera.orthographicSize += 1;
                     yield return new WaitForSeconds(timeCounter / 10);

                 }

                 for (i = camera.orthographicSize; i > 8; i -= 1f)
                 {
                     camera.orthographicSize -= 1;
                     yield return new WaitForSeconds(timeCounter / 10);

                 }
             }
             yield return new WaitForSeconds(0.25f);
             //yield return null;
         }
     }*/
    #endregion

    /*  IEnumerator InvertedCamera()
      {
          while (true)
          {
              //pixelCamera.enabled = false;

              if (inverted == true)
              {

                  while (CameraZ.transform.rotation != Quaternion.Euler(0, 0, 5.1f))
                  {
                      CameraZ.transform.Rotate(0f, 0f, 1f);//0.5f
                      //yield return new WaitForSeconds(timeCounter / 10);
                      yield return null;

                  }

                  while (CameraZ.transform.rotation != Quaternion.Euler(0, 0, -5.1f))
                  {
                      CameraZ.transform.Rotate(0f, 0f, -1f);
                      // yield return new WaitForSeconds(timeCounter / 10);
                      yield return null;

                  }
              }
              yield return null;

          }
          //yield return new WaitForSeconds(0.25f);        

      }*/


    void foreverSong()
    {

    }

    public void allNormal()
    {
        EfeitoRandom = 0;
        // crazy = false;
        // inverted = false;
        // CameraZ.transform.rotation = Quaternion.Euler(0, 0, 0f);
        PlayerMovement.changeControl = false;
        // camera.orthographicSize = 7.25f;
        voices.Stop();
    }


}
