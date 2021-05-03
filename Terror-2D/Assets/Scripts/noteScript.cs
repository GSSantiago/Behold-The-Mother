using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class noteScript : MonoBehaviour
{
    public CircleCollider2D coll;
    bool reading = false;
    bool anim = false;
    public Image noteImage;
    Vector3 pos = new Vector3(0f, 0f, 0f);
    public Volume blurVolume;

    void Start()
    {
        //blurVolume = GameObject.FindGameObjectWithTag("Blur").GetComponent<Volume>();
        blurVolume.weight = 0f;
    }

    void Update()
    {
        if(reading == true)
        {
            if (Input.GetKey(KeyCode.E) && anim == false)
            {
                reading = false;
                StartCoroutine(read_down());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.E) && anim == false)
        {
            if(!reading)
            {
                reading = true;
                
                if (anim == false)
                {
                    StartCoroutine(read_up());
                }
            }
        }
    }

    IEnumerator read_up()
    {
        anim = true;
        pos.y = -1100;
        while((pos.y < 0) && (anim = true))
        {
            pos.y += 40;
            if(pos.y >= 0)
            {
                pos.y = 0;
            }
            yield return new WaitForSeconds(0.03f);
            noteImage.rectTransform.anchoredPosition = pos;
            if (pos.y > -500)
            {
                blurVolume.weight = 1f;
            }

        }
        anim = false;
        Time.timeScale = 0f;
    }

    IEnumerator read_down()
    {
        Time.timeScale = 1f;
        anim = true;
        pos.y = 0;
        while ((pos.y > -1100) && (anim = true))
        {
            pos.y -= 40;
            yield return new WaitForSeconds(0.03f);
            noteImage.rectTransform.anchoredPosition = pos;
            if(pos.y < -500)
            {
                blurVolume.weight = 0f;
            }
        }
        anim = false;
    }
}
