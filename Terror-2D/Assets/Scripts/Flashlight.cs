﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Flashlight : MonoBehaviour
{
    int mode = 0;
    public Light2D luz;
    public int i = 0;
    public float timeCounter;
    public float intensityCounter;
    public bool flicker = false;

    // Start is called before the first frame update
    void Start()
    {
        luz.pointLightOuterAngle = 360;
        luz.pointLightInnerAngle = 360;
        luz.pointLightOuterRadius = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        diff.Normalize();

        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        if(Input.GetKeyDown("f") && mode==0)
        {
            mode0();
            mode = 1;
        }

        else if(Input.GetKeyDown("f") && mode==1)
        {
            mode1();
            mode = 0;
        }

        if(mode == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ-90f);
        }

        if(flicker == false) {
            StartCoroutine(lightFlicker());
        }
    }

    void mode0()
    {
        luz.pointLightOuterAngle = 95;
        luz.pointLightInnerAngle = 30;
        luz.pointLightInnerRadius = 2f;
        luz.pointLightOuterRadius = 9f;
    }

    void mode1()
    {
        luz.pointLightOuterAngle = 360;
        luz.pointLightInnerAngle = 360;
        luz.pointLightInnerRadius = 1.2f;
        luz.pointLightOuterRadius = 4.8f;
    }

    IEnumerator lightFlicker()
    {
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
