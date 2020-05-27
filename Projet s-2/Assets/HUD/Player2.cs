using System.Collections;
using System.Collections.Generic;
using Objets;
using UnityEngine;
using UnityEngine.UI;
/* Author : Stefano Mancinelli et Julien Lung Yut Fong
 *
 * Script pour faire la transition entre le joueur 2 et la barre de vie associée
 */
public class Player2 : MonoBehaviour
{
    [SerializeField]
    private Stat health;
    private Controles2 joueur2;
    private Text winj1;
    private bool wadDead = false;

    private void Awake()
    {
        health.Initialize();
        joueur2 = gameObject.GetComponent<Controles2>();
    }


    void FixedUpdate()
    {
        health.CurrentVal = joueur2.j.pv;
        if (!joueur2.j.isAlive )    
        {
            joueur2.j.demiHauteur = 0.25f;
            if (!wadDead)
            {
                joueur2.transform.Rotate(0,0,90);
                joueur2.j.localrotate = joueur2.transform.rotation;
                wadDead = true;
            }
            
            // WIN JOUEUR 1
        }
    }
}
