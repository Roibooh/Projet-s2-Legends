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
            joueur2.j.localrotate = new Quaternion(joueur2.j.localrotate.z + 90,15,-90,0);

            // WIN JOUEUR 1
        }
    }
}
