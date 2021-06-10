using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[Serializable]
public class DialogueTriggerBehaviour : PlayableBehaviour
{
    public bool JumpToEnd = false;

    private PlayableGraph graph;
    private Playable thisPlayable;
    private EventHandler dialogueEndHandler;
    private bool began = false;

    //Dialogo meu 
    private PlayerMovement playerMovement;
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    private Animator TalkAnim;

    public DialogManager dialogM;

    
    public enum WhosTalking {Rose,Damian};
    [Header("Quem irá falar ? ")]
    public WhosTalking whosTalking;

    public enum direction { Left,Right,Up,Down };
    [Header("Qual direção irá falar ? ")]
    public direction Direction;

    [SerializeField] Dialog dialog;


    public override void OnPlayableCreate(Playable playable)
    {
        graph = playable.GetGraph();
        thisPlayable = playable;
        began = false;
        dialogueEndHandler = OnDialogueEnd;
        dialogM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogManager>();

        if (whosTalking == WhosTalking.Damian)
        {//Se quem estiver falando for o Damian, dar getcomponent nele
            dialogBox = GameObject.Find("/Player/Canvas/DialogBox");
            dialogText = GameObject.Find("/Player/Canvas/DialogBox/Text").GetComponent<Text>();
            TalkAnim = GameObject.Find("/Player").GetComponent<Animator>();

        }

        if (whosTalking == WhosTalking.Rose)
        {//Se quem estiver falando for a Rose, dar getcomponent nele
            dialogBox = GameObject.Find("/RoseBlack/Canvas/RoseDialogBox");
            dialogText = GameObject.Find("/RoseBlack/Canvas/RoseDialogBox/Text").GetComponent<Text>();
            TalkAnim = GameObject.Find("/RoseBlack").GetComponent<Animator>();
        }

       


    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
      
        if (!began && dialogM!=null)
        {
            ChangeDirection();
            DialogManager.Instance.ShowDialog(dialog,dialogBox,dialogText,TalkAnim);
            graph.GetRootPlayable(0).SetSpeed(0);
            began = true;
        }

        if (JumpToEnd) 
            JumpToEndofPlayable();

        if (dialogM.isFinished)
            graph.GetRootPlayable(0).SetSpeed(1);

    }

    public void OnDialogueEnd(object sender, EventArgs args)
    {
      //  DialogueUI.instance.OnDialogueEnd -= dialogueEndHandler;
        //Unpause
        graph.GetRootPlayable(0).SetSpeed(1);
        if (JumpToEnd) JumpToEndofPlayable();
    }

    private void JumpToEndofPlayable()
    {
        graph.GetRootPlayable(0).SetTime(graph.GetRootPlayable(0).GetTime() + thisPlayable.GetDuration());
    }

    private void ChangeDirection()
    {
        switch (Direction)
        {
            case direction.Up:
                TalkAnim.SetFloat("Vertical", (10f));
                break;
            case direction.Left:
                TalkAnim.SetFloat("Horizontal", (-10f));
                break;
            case direction.Down:
                TalkAnim.SetFloat("Vertical", (-10f));
                break;
            case direction.Right:
                TalkAnim.SetFloat("Horizontal", (10f));
                break;
        }
    }
}