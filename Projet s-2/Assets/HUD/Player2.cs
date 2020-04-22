using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    private Controles2 joueur2;
    private Text winj1;

    private void Awake()
    {
        health.Initialize();
        joueur2 = gameObject.GetComponent<Controles2>();
    }


    void FixedUpdate()
    {
        health.CurrentVal = joueur2.j.pv;
        if (!joueur2.j.isAlive)
        {
            joueur2.j.demiHauteur = 0.25f;
            joueur2.transform.localScale = new Vector3(3.6f,0.5f);
            // WIN JOUEUR 1
        }
    }
}
