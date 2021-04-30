using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DontDestroyThis : MonoBehaviour
{

    void Start()
    {
        // Este método impede que o objeto 
        // atual seja destruido durante o carregamento.
        DontDestroyOnLoad(gameObject);
    }
}
