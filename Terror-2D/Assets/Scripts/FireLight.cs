using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireLight : MonoBehaviour
{
    public Light2D luz;
    public int i = 0;
    public float timeCounter;
    public float intensityCounter;
    public bool flicker = false;

    void Update()
    {
        if (flicker == false)
        {
            StartCoroutine(lightFlicker());
        }
    }

    IEnumerator lightFlicker()
    {
        flicker = true;

        for (i = 0; i < 5; i++)
        {
            timeCounter = Random.Range(0.15f, 0.25f);
            intensityCounter = Random.Range(-0.15f, 0.1f);
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
