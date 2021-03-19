using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentWalls : MonoBehaviour
{
    //Referências externas
    public static TransparentWalls Instance;
    private GameObject tWalls; //Paredes transparentes
    private Tilemap tilemap;
    private SpriteMask mySM;
        //Portas
        public int numPortas = 1; //Número de portas associadas à essa colisão
        public GameObject[] portas; //Paredes da sala
        private SpriteRenderer srPorta1;
        //public GameObject porta2; //Paredes da sala

    //Variáveis
    private bool inside = false;
    private bool done = true; //Indica se a transição foi concluída
    //private float previousAlpha = 1;
    private float t = 0; //Usado pelo lerp()
    public float duration = 0.5f; //Duração em segundos da transição
    private Color transparency = new Color(1f, 1f, 1f, 0.2f);
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        // Início tilemap
        tWalls = GameObject.FindGameObjectWithTag("ALTURATRANSPARENCIA");
        tilemap = tWalls.GetComponent<Tilemap>();
        mySM = GetComponent<SpriteMask>();
        mySM.enabled = false;

        // Início portas
        portas = new GameObject[numPortas];
        for(int i = 0; i < numPortas; i++){
        }
    }

    private void OnValidate() {
        if(portas.Length != numPortas)
        {
            //Array.Resize(ref portas, numPortas);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inside){
             tilemap.color = Color.Lerp(tilemap.color, transparency, t);
             if(t<1){
                 t += Time.deltaTime/duration;
             }
        }else{
            if(!done){
                tilemap.color = Color.Lerp(tilemap.color, Color.white, t);
                if(t<1){
                    t += Time.deltaTime/duration;
                }else{
                    mySM.enabled = false;
                    done = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            mySM.enabled = true;
            inside = true;
            done = false;
            t=0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            inside = false;
            t=0;
        }
    }
}
