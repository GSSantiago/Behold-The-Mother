using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityScript : MonoBehaviour
{
    public float sanity_value;
    public Image sanity_image;
    Color cor_atual;

    void Start()
    {
        cor_atual = Color.white;
    }

    void Update()
    {
        cor_atual.a = sanity_value;
        sanity_image.color = cor_atual;
    }
}
