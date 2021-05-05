using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iscoming : MonoBehaviour
{

    public bool FromEntranceHall=false;
    public bool FromWestWing=false;
    public bool FromEastWing=false;
    public int Objective;

    [SerializeField] PauseScript pause;


    // Start is called before the first frame update

    private void Awake()
    {
        if(FromEntranceHall||FromWestWing||FromWestWing)
        Destroy(gameObject);
    }
    void Start()
    {
        pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseScript>();

    }

    // Update is called once per frame
    void Update()
    {
        pause.ObjetivoAtual= Objective;
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
