using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private void Awake()
    {
        health.Initialize();
    }


    void FixedUpdate()
    {
        health.CurrentVal = gameObject.GetComponent<Controles2>().j.pv;
    }
}
