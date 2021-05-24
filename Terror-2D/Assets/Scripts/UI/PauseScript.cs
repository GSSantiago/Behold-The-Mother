using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    public Volume blurVolume;

    [SerializeField] Text ObjectiveText;
    public int ObjetivoAtual=0;

    [SerializeField] ObjeticveList objetivoLista;

    [SerializeField] Iscoming objetivo;

    private GameObject Canvas_Sanity;
    private GameObject GameManager;

    private void OnLevelWasLoaded(int level)
    {
        Canvas_Sanity = GameObject.Find("Canvas_Sanity");
        GameManager = GameObject.Find("GameManager");


    }

    void Start()
    {
        blurVolume.weight = 0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.SetActive(false);
        objetivo = GameObject.FindGameObjectWithTag("Coming").GetComponent<Iscoming>();
    }
    void Update()
    {
        ObjetivoAtual = objetivo.Objective;
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
        objetivos();
    }

    public void Menu()
    {
        Destroy(GameManager);
        Destroy(Canvas_Sanity);
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void objetivos()
    {
        ObjectiveText.text = objetivoLista.Lines[ObjetivoAtual];
    }
}
