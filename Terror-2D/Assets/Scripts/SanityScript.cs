using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SanityScript : MonoBehaviour
{

    public float sanity_value;
    public Image sanity_image;
    Color cor_atual;
    bool ciclo = false;
    int i, j;
    float timeCounter;
    int repeticoes;

    private Scene scene;
    private string sceneName;



    private void OnLevelWasLoaded(int level)
    {
        verify();
    }

    void Start()
    {
        //imagem padrão, com a sanidade em nível normal
        sanity_value = 100;
        cor_atual = Color.white;
        cor_atual.a = (1 - (sanity_value / 100));
        sanity_image.color = cor_atual;
        //StartCoroutine(pulse());
        verify();
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            sanity_value = 100;
        }

        if (sanity_value <= 0)
        {
            sanity_value = 0;
            SceneManager.LoadScene("DefeatScene");

        }

        //criando intervalos de valores e respectivos tempos para as pulsações
        if (sanity_value < 20)
        {
            timeCounter = 0.001f;
        }

        else if (sanity_value < 40)
        {
            timeCounter = 0.005f;
        }

        else if (sanity_value < 60)
        {
            timeCounter = 0.01f;
        }

        else if (sanity_value < 80)
        {
            timeCounter = 0.05f;
        }

        else
        {
            timeCounter = 0.1f;
        }


        //repete o ciclo infinitamente
        if (ciclo == false && sanity_value < 80)
        {
            StartCoroutine(pulse());
        }
    }

    IEnumerator pulse()
    {
        //dois loops, um para aparecer a imagem, o outro para apagar
        // while (true)
        //  {
        if (ciclo == false)
        {
            ciclo = true;

            for (i = 0; i < (1 - (sanity_value / 100)) * 100; i++)
            {
                cor_atual.a = (float)i / 200;
                sanity_image.color = cor_atual;
                yield return new WaitForSeconds(timeCounter / 10);
                j = i;
            }

            for (i = j; i > 0; i--)
            {
                cor_atual.a = (float)i / 200;
                sanity_image.color = cor_atual;
                yield return new WaitForSeconds(timeCounter / 10);

            }

            ciclo = false;
            //}
            // yield return null;
        }
    }

    void verify()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if (sceneName == "MenuPrincipal")
        {
            sanity_image.enabled = false;
        }
        else
        {
            sanity_image.enabled = true;

        }
    }
}
