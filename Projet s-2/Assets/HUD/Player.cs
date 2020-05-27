using System;
using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
using UnityEngine.UI;
/* Author : Stefano Mancinelli et Julien Lung Yut Fong
 *
 * Script pour faire la transition entre le joueur et la barre de vie associée
 */
public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    private Controles joueur;
    private Text winj2;
    private bool wasDead = false;

    private void Awake()
    {
        health.Initialize();
        joueur = gameObject.GetComponent<Controles>();
    }

    void FixedUpdate()
    {
        health.CurrentVal = joueur.j.pv;
        if (!joueur.j.isAlive)
        {
            joueur.j.demiHauteur = 0.25f;
            if (!wasDead)
            {
                joueur.transform.Rotate(new Vector3(0,0,90));
            }

            wasDead = true;
            // WIN JOUEUR 2
        }
    }
}
