using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Iniciar jogo");
        SceneManager.LoadScene("Entrance Hall");
    }

    public void Quit()
    {
        Debug.Log("Sair");
        Application.Quit();
    }
}
