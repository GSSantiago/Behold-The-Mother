using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Flashlight : MonoBehaviour
{
    int mode = 0;
    Light2D luz;
    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light2D>();
        luz.pointLightOuterAngle = 360;
        luz.pointLightInnerAngle = 360;
        luz.pointLightOuterRadius = 4.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f") && mode==0)
        {
            luz.pointLightOuterAngle = 95;
            luz.pointLightInnerAngle = 30;
            luz.pointLightOuterRadius = 9;
            mode = 1;
        }

        else if(Input.GetKeyDown("f") && mode==1)
        {
            luz.pointLightOuterAngle = 360;
            luz.pointLightInnerAngle = 360;
            luz.pointLightOuterRadius = 4.8f;
            mode = 0;
        }
    }
}
