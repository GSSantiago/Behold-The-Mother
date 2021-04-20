using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SanityControl : MonoBehaviour
{

    public GameObject CircleSanity;
    public Transform Player;
    public Transform enemy;
    public SanityScript sanity;
    public PlayerMovement PlayerMovement;
    public PixelPerfectCamera pixelCamera;
    public Camera camera;
    public Transform CameraZ;


    int EfeitoRandom;
    bool crazy;
    bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(efeitos());
        StartCoroutine(crazyCamera());
        StartCoroutine(InvertedCamera());
    }


    // Update is called once per frame
    void Update()
    {
        //5 É uma distancia boa
       // if (Vector3.Distance(Player.position, enemy.position) > 5)
          //  CircleSanity.SetActive(false);
      //  else
          //  CircleSanity.SetActive(true);


        if (Input.GetKey(KeyCode.P))
        {

            Debug.Log("Efeito random =2 ");
            EfeitoRandom = 3;
        }
    }

    IEnumerator efeitos()
    {
        while (true)
        {
            if (sanity.sanity_value < 75)
            {
                switch (EfeitoRandom)
                {
                    case 1:
                        twistedControl();
                        break;

                    case 2:
                        crazy = true;
                        break;

                    case 3:
                        inverted = true;
                        break;

                    case 4:
                        //foreverSong();
                        break;
                    default:
                        EfeitoRandom = Random.Range(1, 4);
                        Debug.Log("Efeito é" + EfeitoRandom);
                        break;
                }
            }
            else
            {
                allNormal();
            }

            yield return null;
        }
    }

    void twistedControl()
    {
        PlayerMovement.changeControl = true;
    }

    #region crazyCamera
    int CameraRandom;
    float timeCounter = 1f;//antes tava 1f

    IEnumerator crazyCamera()
    {
        while (true)
        {
            int i;

            if (crazy == true)
            {
                CameraRandom = Random.Range(21, 35);
                for (i = pixelCamera.assetsPPU; i < CameraRandom; i += 1)
                {
                    pixelCamera.assetsPPU += 1;
                    yield return new WaitForSeconds(timeCounter / 10);

                }

                for (i = pixelCamera.assetsPPU; i > 16; i -= 1)
                {
                    pixelCamera.assetsPPU -= 1;
                    yield return new WaitForSeconds(timeCounter / 10);

                }
            }
            yield return new WaitForSeconds(0.25f);
            //yield return null;
        }
    }
    #endregion

    IEnumerator InvertedCamera()
    {
        while (true)
        {
            pixelCamera.enabled = false;

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

    }


    void foreverSong()
    {

    }

    void allNormal()
    {
        EfeitoRandom = 0;
        crazy = false;
        PlayerMovement.changeControl = false;
        camera.orthographicSize = 7.25f;
        pixelCamera.enabled = true;
    }


}
