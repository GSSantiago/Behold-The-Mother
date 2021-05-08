using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logoFade : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject logoCanvas;
    public Image logo;
    bool anim = false;
    Color cor_atual;
    int i;

    void Start()
    {
        cor_atual = Color.white;
        logo.color = cor_atual;
    }
    
    void Update()
    {
        if (!anim)
        {
            StartCoroutine(fade());
        }    
    }

    IEnumerator fade()
    {
        anim = true;
        for(i=100; i >= 0; i--)
        {
            cor_atual.a -= 0.01f;
            yield return new WaitForSeconds(0.015f);
            logo.color = cor_atual;
        }

        logoCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }
}
