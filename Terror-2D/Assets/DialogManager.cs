using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] PlayerMovement playerMovement;


    [SerializeField] int lettersPerSecond;
   // public Animator anim;


    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
   
    public void ShowDialog(Dialog dialog)
    {
        this.dialog = dialog;
        dialogBox.SetActive(true);
        playerMovement.enabled = false;
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }
    //antes era handleupdate
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !isTyping && dialogBox.active)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                playerMovement.enabled = true;
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
      //  anim.SetBool("Istalking", true);
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
       // anim.SetBool("Istalking", false);

    }
}
