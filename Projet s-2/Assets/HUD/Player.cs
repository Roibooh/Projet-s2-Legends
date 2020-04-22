using System;
using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    private Controles joueur;
    private Text winj2;

    private void Awake()
    {
        health.Initialize();
        joueur = gameObject.GetComponent<Controles>();
    }

    void FixedUpdate()
    {
        health.CurrentVal = joueur.j.pv;
        if (!joueur.j.isAlive )
        {
            joueur.j.demiHauteur = 0.25f;
            joueur.transform.localScale = new Vector3(3.6f,0.5f);
            // WIN JOUEUR 2
        }
    }
}
