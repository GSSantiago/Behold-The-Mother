using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Iscoming : MonoBehaviour
{

    public bool FromEntranceHall=false;
    public bool FromWestWing=false;
    public bool FromEastWing=false;
    public bool FromUpperWestWing = false;
    public bool FromMasterStudyUp = false;

    public bool ispickaxePicked = false;
    public bool isKeyPicked = false;
    public int Objective;

    public bool PickaxeDisplay = false;
    public bool KeyDisplay = false;

    public bool isFirstcutscenePlayed = false;
    public bool isLastcutscenePlayed = false;

    [SerializeField] PauseScript pause;
    [SerializeField] Image key;
    [SerializeField] Image pickaxe;
    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject RoseBlack;
   

    private Scene scene;
    private string sceneName;
    private AudioSource ambienceSound;


    // Start is called before the first frame update

    private void OnLevelWasLoaded(int level)
    {
        pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseScript>();
        key = GameObject.FindGameObjectWithTag("Key").GetComponent<Image>();
        pickaxe = GameObject.FindGameObjectWithTag("Pickaxe").GetComponent<Image>();
        ambienceSound = GetComponent<AudioSource>();

        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "Entrance Hall" && !ambienceSound.isPlaying)
            ambienceSound.Play();

        cutscene = GameObject.Find("TimelineManager");
        RoseBlack = GameObject.Find("RoseBlack");

        if (isFirstcutscenePlayed)
        {
            Destroy(cutscene);
            Destroy(RoseBlack);

    
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (pause != null) { pause.ObjetivoAtual = Objective; }
        if (key != null) { key.enabled = KeyDisplay; }
        if (pickaxe != null) { pickaxe.enabled = PickaxeDisplay; }

    }

   

    public void fromEntranceHall()
    {
        FromEntranceHall = true;
        FromWestWing = false;
        FromEastWing = false;
        FromMasterStudyUp = false;
        FromUpperWestWing = false;


    }

    public void fromWestWing()
    {
        FromEntranceHall = false;
        FromWestWing = true;
        FromEastWing = false;
        FromMasterStudyUp = false;
    }

    public void fromEastWing()
    {
        FromEntranceHall = false;
        FromWestWing = false;
        FromEastWing = true;
        FromMasterStudyUp = false;
    }

    public void fromUpperWestWing()
    {
        FromEntranceHall = false;
        FromWestWing = false;
        FromEastWing = false;
        FromUpperWestWing = true;
        FromMasterStudyUp = false;
    }

    public void fromMasterStudyUp()
    {
        FromEntranceHall = false;
        FromWestWing = false;
        FromEastWing = false;
        FromUpperWestWing = false;
        FromMasterStudyUp = true;
    }
 
}
