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

    public void Retry()
    {
        SceneManager.LoadScene("Entrance Hall");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
