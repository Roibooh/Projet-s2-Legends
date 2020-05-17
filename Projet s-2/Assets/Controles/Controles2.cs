using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
/* Author : Guillaume MERCIER et Julien Lung Yut Fong
 *
 * Script permettant la liaison entre le joueur le jeu et l'objet joueur
 */
namespace Objets
{
    public class Controles2 : MonoBehaviour
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
        protected internal Animator anim;


        //Ici on va rajouter les états, pour savoir on peut faire quoi dans chaque état, par exemple pour les attaques
         // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>(); 
            j = new Joueur(nom,pv,transform.position,demiHauteur,demiLargeur,masse,transform.localScale,transform.localRotation,nbSauts);
            string[] keyList = {"r", "t", "q","d","z","s"};
            c = new Joueur.Controle(unite,keyList);
        }
        // Update is called once per frame
        void FixedUpdate()
        {

            #region GestionTouches

            (c,j)=Joueur.keyHandeler(c,j,anim);

            transform.position = j.UpdatePositionJoueur();
            transform.localScale = j.localscale;
            transform.localRotation = j.localrotate;
            
            #endregion
            
            #region Etats
            
            if (j.etats[Joueur.knocked].actif)
            {
                j.position = new Vector3(j.position.x+0.15f*j.directionProj,j.position.y,j.position.z);
            }
            if (j.position.y > demiHauteur)
            {
                j.etats[Joueur.flying].setTimer(2);
            }
            foreach (var etat in j.etats)
            {
                etat.update();
            }
            #endregion
            
        }
    }
}