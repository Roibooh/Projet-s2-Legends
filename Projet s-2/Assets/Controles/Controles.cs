﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
/* Author : Julien Lung Yut Fong et Guillaume MERCIER
 *
 * Script permettant la liaison entre le joueur le jeu et l'objet joueur
 */
namespace Objets
{
    public class Controles : MonoBehaviour
    {
        [SerializeField] protected internal string nom = "Test";
        [SerializeField] protected internal int pv = 100;
        [SerializeField] protected internal int demiHauteur = 1;
        [SerializeField] protected internal int demiLargeur = 1;
        [SerializeField] protected internal int masse = 3;
        [SerializeField] protected internal int nbSauts = 3;
        [SerializeField] protected internal float unite = (float)0.45;// mvspd perso

        protected internal Joueur j;
        protected internal Joueur.Controle c;
        protected internal Personnages.Personnages.Personnage p;
        protected internal Animator anim;


        //Ici on va rajouter les états, pour savoir on peut faire quoi dans chaque état, par exemple pour les attaques
         // Start is called before the first frame update
        void Awake()
        {
            anim = GetComponent<Animator>(); 
            j = new Joueur(nom,pv,transform.position,demiHauteur,demiLargeur,masse,transform.localScale,transform.localRotation,nbSauts);
            c = new Joueur.Controle(unite);
            p = Personnages.Personnages.perso1;
            
            
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            #region GestionEtats
            
            j = Joueur.etatHandler(j,p,anim);
            
            #endregion

            #region GestionTouches

            (c,j)=Joueur.keyHandeler(c,j,anim,p);

            transform.position = j.UpdatePositionJoueur();
            transform.localScale = j.localscale;
            transform.localRotation = j.localrotate;
            
            #endregion

            
        }
    }
}