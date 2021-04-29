using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Entrance Hall");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Entrance Hall");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
