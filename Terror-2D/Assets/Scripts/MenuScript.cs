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
    /*public GameObject logoCanvas;
    public Image logo;
    public bool anim = false;
    bool finished = true;
    Color cor_atual;
    int i;*/

    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
       
        MenuCanvas.SetActive(true);
        InstructionCanvas.SetActive(false);
        InstructionCanvasPg2.SetActive(false);
        CreditsCanvas.SetActive(false);
        //logoCanvas.SetActive(false);
        /*anim = false;
        finished = true;
        cor_atual = Color.white;
        logo.color = cor_atual;*/
    }
    /*public void Update()
    {
        Debug.Log(finished);
        if (!anim)
        {
            finished = false;
            StartCoroutine(fade());
        } 
        else if(finished)
        {

            logoCanvas.SetActive(false);
        }
    }*/

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
    /*IEnumerator fade()
    {
        logoCanvas.SetActive(true);
        anim = true;
        for (i = 100; i >= 0; i--)
        {
            cor_atual.a -= 0.01f;
            yield return new WaitForSeconds(0.015f);
            logo.color = cor_atual;
        }

        finished = true;
        yield return new WaitForSeconds(0.5f);
        logoCanvas.SetActive(false);
        
    }*/
}
