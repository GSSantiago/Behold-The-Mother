using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iscoming : MonoBehaviour
{

    public bool FromEntranceHall=false;
    public bool FromWestWing=false;
    public bool FromEastWing=false;

    public bool ispickaxePicked = false;
    public bool isKeyPicked = false;
    public int Objective;

    public bool PickaxeDisplay = false;
    public bool KeyDisplay = false;

    [SerializeField] PauseScript pause;
    [SerializeField] Image key;
    [SerializeField] Image pickaxe;


    // Start is called before the first frame update

    private void OnLevelWasLoaded(int level)
    {
        pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseScript>();
        key = GameObject.FindGameObjectWithTag("Key").GetComponent<Image>();
        pickaxe = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<Image>();

    }
    // Update is called once per frame
    void Update()
    {
        pause.ObjetivoAtual= Objective;
        key.enabled = KeyDisplay;
        pickaxe.enabled= PickaxeDisplay;

    }

    void iscoming()
    {
     
    }

    public void fromEntranceHall()
    {
        FromEntranceHall = true;
        FromWestWing = false;
        FromEastWing = false;
        
    }

    public void fromWestWing()
    {
        FromEntranceHall = false;
        FromWestWing = true;
        FromEastWing = false;
    }

    public void fromEastWing()
    {
        FromEntranceHall = false;
        FromWestWing = false;
        FromEastWing = true;
    }
}
