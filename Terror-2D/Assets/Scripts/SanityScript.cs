using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityScript : MonoBehaviour
{
    public float sanity_value;
    public Image sanity_image;
    Color cor_atual;
    bool ciclo = false;
    int i, j;
    float timeCounter;
    int repeticoes;

    void Start()
    {
        //imagem padrão, com a sanidade em nível normal
        sanity_value = 1;
        cor_atual = Color.white;
        cor_atual.a = (1 - sanity_value);
        sanity_image.color = cor_atual;
    }

    void Update()
    {
        if (Input.GetKey("h"))
        {
            sanity_value -= 0.01f;
        }

        if(sanity_value <= 0)
        {
            sanity_value = 1;
        }

        
        //criando intervalos de valores e respectivos tempos para as pulsações
        if (sanity_value < 0.2)
        {
            timeCounter = 0.001f;
        } 
        
        else if (sanity_value < 0.4)
        {
            timeCounter = 0.005f;
        } 
        
        else if(sanity_value < 0.6)
        {
            timeCounter = 0.01f;
        } 
        
        else if(sanity_value < 0.8)
        {
            timeCounter = 0.05f;
        } 
        
        else
        {
            timeCounter = 0.1f;
        }

        //repete o ciclo infinitamente
        if(ciclo == false)
        {
            StartCoroutine(pulse());
        }
    }

    IEnumerator pulse()
    {
        //dois loops, um para aparecer a imagem, o outro para apagar
        ciclo = true;

        for (i = 0; i < (1 - sanity_value) * 100; i++)
        {
            cor_atual.a = (float) i / 200;
            sanity_image.color = cor_atual;
            yield return new WaitForSeconds(timeCounter/10);
            j = i;
        }

        for (i = j; i > 0; i--)
        {
            cor_atual.a = (float) i / 200;
            sanity_image.color = cor_atual;
            yield return new WaitForSeconds(timeCounter/10);

        }

        ciclo = false;
    }
}
