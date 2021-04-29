using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    public Volume blurVolume;
    [SerializeField] GameManagerHall objective;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        blurVolume.weight = 0f;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        blurVolume.weight = 1f;
        objective.objetivos();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
