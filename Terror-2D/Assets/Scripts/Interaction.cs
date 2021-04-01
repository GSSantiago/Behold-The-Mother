using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //Referências externas
    private GameObject glow;
    private SpriteRenderer myGlow;
    private CircleCollider2D detect; //Collider

    //Constante
    private Color transparency = new Color(1f, 1f, 1f, 0.2f);

    //Variáveis
    public float duration = 1f; //Duração da transição
    private bool inside = false; //Se o player está dentro da área de interação
    private float t = 0; //Utilizado pelo lerp
    private bool done = false; //Diz se a transição está concluída
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject glow = transform.GetChild(0).gameObject;
        SpriteRenderer myGlow = glow.GetComponent<SpriteRenderer>();
        CircleCollider2D detect = GetComponent<CircleCollider2D>();
        myGlow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inside){
             myGlow.color = Color.Lerp(myGlow.color, transparency, t);
             if(t<1){
                 t += Time.deltaTime/duration;
             }
        }else{
            if(!done){
                myGlow.color = Color.Lerp(myGlow.color, Color.white, t);
                if(t<1){
                    t += Time.deltaTime/duration;
                }else{
                    myGlow.enabled = false;
                    done = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(detect.gameObject.tag == "Player"){
            inside = true;
            myGlow.enabled = true;
            
            t = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(detect.gameObject.tag == "Player"){
            inside = false;
            t = 0;
        }
    }
}
