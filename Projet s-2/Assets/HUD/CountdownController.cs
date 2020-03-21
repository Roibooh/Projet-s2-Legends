using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    countdownDisplay.text = "GAMER OVER!";
    
    yield return new WaitForSeconds(1F);
    
    countdownDisplay.gameObject.SetActive(false);
  }
  
}
