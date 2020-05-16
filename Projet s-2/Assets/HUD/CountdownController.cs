using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* Author : Stefano Mancinelli
 *
 * Classe du conteur
 */
public class CountdownController : MonoBehaviour
{
  public int countdownTime;
  public Text countdownDisplay;

  private void Start()
  {
    StartCoroutine(CountdownToStart());
  }


  IEnumerator CountdownToStart()
  {
    while (countdownTime > 0)
    {
      countdownDisplay.text = countdownTime.ToString();
      
      yield return new WaitForSeconds(1f);

      countdownTime--;
    }

    countdownDisplay.text = "GAME OVER!";
    
    yield return new WaitForSeconds(1F);
    
    countdownDisplay.gameObject.SetActive(false);
  }
  
}
