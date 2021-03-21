using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CopyTilemapColor : MonoBehaviour
{
    private GameObject tWalls; //Paredes transparentes
    private Tilemap tilemap;
    private SpriteRenderer mySR;
    public SpriteMask mySM;

    // Start is called before the first frame update
    void Start()
    {
        tWalls = GameObject.FindGameObjectWithTag("ALTURATRANSPARENCIA");
        tilemap = tWalls.GetComponent<Tilemap>();
        mySR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!mySM.enabled){
            mySR.color = Color.white;
        }else{
            mySR.color = tilemap.color;
        }
        //ok se voce ta lendo isso e falando meu deus
        // demorou quanto tempo pra faze issu, dois segundo
        // NAO OK, NAO.
    }
}
