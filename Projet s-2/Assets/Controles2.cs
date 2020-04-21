﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Objets
{
    public class Controles2 : MonoBehaviour
    {
        [SerializeField] private string nom = "Test";
        [SerializeField] private int pv = 100;
        [SerializeField] private int demiHauteur = 1;
        [SerializeField] private int demiLargeur = 1;
        [SerializeField] private int masse = 3;
        [SerializeField] private int nbSauts = 3;
        [SerializeField] private float unite = (float)0.45;// mvspd perso
        private bool upKeyAlreadyPressed;
        private bool leftKeyAlreadyPressed;
        private bool rigthKeyAlreadyPressed;
        private bool downKeyAlreadyPressed;
        private Joueur j;
            protected internal enum Etat
         {
              Attacking, 
              Crouch, 
              Normal,
              Invincible,
              Stunt
         }
         //Ici on va rajouter les états, pour savoir on peut faire quoi dans chaque état, par exemple pour les attaques
         // Start is called before the first frame update
        void Start()
        {
            j = new Joueur(nom,pv,transform.position,demiHauteur,demiLargeur,masse,nbSauts);
            upKeyAlreadyPressed = false; 
            leftKeyAlreadyPressed = false;
            rigthKeyAlreadyPressed = false;
            downKeyAlreadyPressed = false;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 e = new Vector3(0,(float)-0.5,0);
            ObjetsMovibles o = new ObjetsMovibles(e, (float)0.5, 50);
            
            
            if (Input.GetKey("z") && j.nbSauts > 0)// haut
            {
                if (!upKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, unite);
                    upKeyAlreadyPressed = true;
                }
            } 
            else
            {
                if (upKeyAlreadyPressed)
                {
                    j.nbSauts--;
                    upKeyAlreadyPressed = false;
                }

                if (j.position.y <= demiHauteur)
                {
                    j.nbSauts = j.nbSautsMax;
                }
            }
            if (Input.GetKey("s")) //bas
            {
                if (j.Vitesse.y < 0)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - unite * 2);
                }
                if (!downKeyAlreadyPressed) // accroupi and fastfall
                {
                    j.demiHauteur /= 2;
                    j.position.y -= j.demiHauteur;
                    transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y/2);
                    downKeyAlreadyPressed = true;
                }
            }
            else
            {
                if (downKeyAlreadyPressed)// Reprendre forme normale
                {
                    j.position.y += j.demiHauteur;
                    j.demiHauteur *= 2;
                    transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*2);
                    downKeyAlreadyPressed = false;
                }
            }
            
            if (Input.GetKey("d"))//droite
            {
                if (!rigthKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x + unite, j.Vitesse.y);
                    rigthKeyAlreadyPressed = true;
                }
            }
            else
            {
                if (rigthKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x - unite, j.Vitesse.y);
                    rigthKeyAlreadyPressed = false;
                }
            }
            if (Input.GetKey("q"))//gauche
            {
                if (!leftKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x - unite, j.Vitesse.y);
                    leftKeyAlreadyPressed = true;
                }
            }
            else
            {
                if (leftKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x + unite, j.Vitesse.y);
                    leftKeyAlreadyPressed = false;
                }
            }
            transform.position = j.UpdatePositionJoueur();
            //ObjetsMovibles j1 = new Joueur("k",100,Joueur1.position,1,1,1,2); test 
        }
    }
}