using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject InstructionCanvas;
    public GameObject InstructionCanvasPg2;
    public GameObject CreditsCanvas;

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
       
        MenuCanvas.SetActive(true);
        InstructionCanvas.SetActive(false);
        InstructionCanvasPg2.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Entrance Hall");
    }

    public void Instruction()
    {
        MenuCanvas.SetActive(false);
        InstructionCanvas.SetActive(true);
    }

    public void NextPageInstruction()
    {
        InstructionCanvas.SetActive(false);
        InstructionCanvasPg2.SetActive(true);
    }

    public void PreviousPageInstruction()
    {
        InstructionCanvas.SetActive(true);
        InstructionCanvasPg2.SetActive(false);
    }

    public void Credits()
    {
        MenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    public void BacktoMenu()
    {
        MenuCanvas.SetActive(true);
        InstructionCanvas.SetActive(false);
        InstructionCanvasPg2.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
