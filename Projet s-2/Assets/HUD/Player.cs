using System;
using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    private void Awake()
    {
        health.Initialize();
    }


    void FixedUpdate()
    {
        health.CurrentVal = gameObject.GetComponent<Controles>().j.pv;
    }
}
