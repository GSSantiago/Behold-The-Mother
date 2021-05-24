using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    //public Slider staminaBar;
    private float maxStamina = 100;
    public float currentStamina;


    //  public static StaminaBar instance;
    [SerializeField] AudioSource cansaçoSound;
    private Coroutine regen;


  /*  private void Awake()
    {
       instance = this;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        //staminaBar.maxValue = maxStamina;
        //staminaBar.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
     if(currentStamina - amount >=0 )
        {
            if (!cansaçoSound.isPlaying)
                cansaçoSound.Play();

            currentStamina -= amount;
           // staminaBar.value = currentStamina;

           cansaçoSound.volume = (1-(currentStamina/100));

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
     
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);
        while (currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            //staminaBar.value = currentStamina;
            cansaçoSound.volume = (1 - (currentStamina / 100));

            yield return new WaitForSeconds(0.1f);
        }
        regen = null;
    }

}
