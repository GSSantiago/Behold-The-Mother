using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Pathfinding;

public class Flashlight : MonoBehaviour
{
    int mode = 0;
    public Light2D luz;
    [HideInInspector]public int i = 0;
    public float timeCounter;
    public float intensityCounter;
    public float length = 12f;
    [HideInInspector] public bool flicker = false;
    public GameObject player;
    public PlayerMovement PlayerMove;
    [HideInInspector] public Vector3 pos;
    public LayerMask layerMask;
    public AIPath InimigoIA;

    //encontrando a posicao correta do mouse
    //meio caótico e eu n sei bem como funciona, mas funciona entao to feliz
    public static Vector3 MouseWorldPos()
    {
        Vector3 vec = MouseWorldPosWithZ(Input.mousePosition, Camera.main); ;
        vec.z = 0f;
        return vec;
    }

    public static Vector3 MouseWorldPosWithZ()
    {
        return MouseWorldPosWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 MouseWorldPosWithZ(Camera worldCamera)
    {
        return MouseWorldPosWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 MouseWorldPosWithZ(Vector3 ScreenPosition, Camera worldCamera)
    {
        Vector3 worldPos = worldCamera.ScreenToWorldPoint(ScreenPosition);
        return worldPos;
    }


    void Start()
    {
        //player = GameObject.Find("Player");
        PlayerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //modo padrão da luz
        luz.pointLightOuterAngle = 360;
        luz.pointLightInnerAngle = 360;
        luz.pointLightOuterRadius = 4.8f;
    }

    void FixedUpdate()
    {
        //luz em modo padrao
        luz.pointLightOuterAngle = 360;
        luz.pointLightInnerAngle = 360;
        luz.pointLightInnerRadius = 1.2f;
        luz.pointLightOuterRadius = 4.8f;
        mode = 0;
        PlayerMove.normalSpeed = 5f;
        PlayerMove.runSpeed = 8f;

        //encontra a direção do mouse na tela para rotacionar a luz
        //mas e um codigo diferente do raycast
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        //mantem a velocidade do inimigo padrao
        InimigoIA.maxSpeed = 2f;

        while(Input.GetKey(KeyCode.Mouse0) && mode==0)
        {
            //entra no modo alternativo de luz
            luz.pointLightOuterAngle = 80;
            luz.pointLightInnerAngle = 20;
            luz.pointLightInnerRadius = 2f;
            luz.pointLightOuterRadius = 12f;
            luz.intensity = 2f;

            //direciona o feixe
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
            PlayerMove.normalSpeed = 3f;
            PlayerMove.runSpeed = 6f;
            mode = 1;

            //cria o raycast e detecta a colisao
            Vector3 mousepos = MouseWorldPos();
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousepos, length, layerMask, -100f, 100f);
            Debug.DrawRay(luz.transform.position, mousepos, Color.red);
            if(hit.collider != null)
            {
                //diminui a velocidade do inimigo
                InimigoIA.maxSpeed = 0.5f;
                Debug.Log("Luz no monstro!!!!!");
            }
        }

        if(flicker == false && mode == 0) {
            StartCoroutine(lightFlicker());
        }
        if (gameObject.name == "Point Light 2D") {

            if (PlayerMove.moveDir.x == -1)
            {
                //posicao da lanterna para a esqueda
                pos = player.transform.position;
                pos.x -= 0.55f;
                pos.y += 0.10f;
                luz.transform.position = pos;
            }
            if (PlayerMove.moveDir.x == 1)
            {
                //posicao padrao da lanterna
                pos = player.transform.position;
                pos.x += 0.55f;
                pos.y += 0.10f;
                luz.transform.position = pos;
            }

            if (PlayerMove.moveDir.y == 1)
            {
                //posicao da lanterna para cima
                pos = player.transform.position;
                pos.x -= 0.20f;
                pos.y += 0.45f;
                luz.transform.position = pos;
            }

            if (PlayerMove.moveDir.y == -1)
            {
                //posicao da lanterna para baixo
                pos = player.transform.position;
                pos.x += 0.20f;
                pos.y -= 0.15f;
                luz.transform.position = pos;
            }
        }
    }

    IEnumerator lightFlicker()
    {
        //função para animação de 'fogo'
        flicker = true;

        for (i = 0; i< 5; i++)
        {
            timeCounter = Random.Range(0.01f, 0.2f);
            intensityCounter = Random.Range(-0.1f, 0.1f);
            luz.intensity += intensityCounter;
            yield return new WaitForSeconds(timeCounter);
            if (luz.intensity >= 1)
            {
                luz.intensity = 1;
            }
            if (luz.intensity <= 0.6)
            {
                luz.intensity = 0.6f;
            }
        }

        flicker = false;
    }
}
