using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private void Awake()
    {
        health.Initialize();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            health.CurrentVal += 10;
        }
    }
}
