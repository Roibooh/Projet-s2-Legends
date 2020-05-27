using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* Author : Stefano Mancinelli
 *
 * Classe des barres de vie
 */
public class BarScript : MonoBehaviour
{
    private float fillAmount;
  
    [SerializeField]
    private float lerpSpeed;
    
    [SerializeField]
    private Image health;
 

    public float MaxValue { get; set; }

    public float Value
    {
        set { fillAmount = Map(value, 0, MaxValue, 0, 1); }
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmount != health.fillAmount)
        {
            health.fillAmount = Mathf.Lerp(health.fillAmount,fillAmount,Time.deltaTime * lerpSpeed );
        }

        
    }
    
    private float Map(float val, float inMin, float inMax, float outMin, float outMax)
    {
        return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        // ex: (80 - 0) * (1 - 0) / (100 - 0) + 0
        //        (80 * 1) / 100 = 0,8
    }
    
}
