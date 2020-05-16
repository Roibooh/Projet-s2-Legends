using System.Collections;
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
        [SerializeField] private string nom = "Test";
        [SerializeField] private int pv = 100;
        [SerializeField] private int demiHauteur = 1;
        [SerializeField] private int demiLargeur = 1;
        [SerializeField] private int masse = 3;
        [SerializeField] private int nbSauts = 3;
        [SerializeField] private float unite = (float)0.45;// mvspd perso
        private int direction = 0; // 180 = gauche
        private bool upKeyAlreadyPressed;
        private bool leftKeyAlreadyPressed;
        private bool rigthKeyAlreadyPressed;
        private bool downKeyAlreadyPressed;
        protected internal int directionProj = 0;
        protected internal Joueur j;
        private Animator anim;
        
            
         //Ici on va rajouter les états, pour savoir on peut faire quoi dans chaque état, par exemple pour les attaques
         // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>(); 
            j = new Joueur(nom,pv,transform.position,demiHauteur,demiLargeur,masse,nbSauts);
            upKeyAlreadyPressed = false; 
            leftKeyAlreadyPressed = false;
            rigthKeyAlreadyPressed = false;
            downKeyAlreadyPressed = false;
        }
        // Update is called once per frame
        void FixedUpdate()
        {

            #region GestionTouches

            if (!j.etats[Joueur.stunned].actif)
            {
                if (Input.GetKey("[1]")&& !j.etats[Joueur.attacking].actif)
                {
                    anim.Play("Hit");
                    j.etats[Joueur.attacking].Timer = 35;
                }
                if (Input.GetKey("[2]")&& !j.etats[Joueur.attacking].actif)
                {
                    anim.Play("Hitup");
                    j.etats[Joueur.attacking].Timer = 35;
                }
                if (j.isAlive && Input.GetKey("up") && j.nbSauts > 0) // haut
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


                if (j.isAlive && Input.GetKey("down")) //fastfall
                {
                    if (j.Vitesse.y < 0)
                    {
                        if (j.Vitesse.y - unite * 2 > -j.vitessemax*2)
                        {
                            j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - unite * 2);
                        }
                    }

                    if (Input.GetKey("[1]")&& !j.etats[Joueur.attacking].actif && j.etats[Joueur.flying].actif)
                    {
                        anim.Play("Spike");
                        j.etats[Joueur.attacking].Timer = 35;
                    }

                    if (!downKeyAlreadyPressed && !j.etats[Joueur.flying].actif) // accroupi
                    {
                        j.demiHauteur /= 2;
                        j.position.y -= j.demiHauteur;
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2);
                        downKeyAlreadyPressed = true;
                        j.etats[Joueur.crouched].Timer = 2;
                    }
                }
                else
                {
                    if (downKeyAlreadyPressed) // Reprendre forme normale
                    {
                        j.position.y += j.demiHauteur;
                        j.demiHauteur *= 2;
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2);
                        downKeyAlreadyPressed = false;
                    }
                }

                if (j.isAlive && Input.GetKey("right")) //droite
                {
                    if (!rigthKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x + unite, j.Vitesse.y);
                        rigthKeyAlreadyPressed = true;

                        if (direction == 180)
                        {
                            direction = 0;
                            this.transform.localRotation = new Quaternion(0, direction, 0, 0);
                        }
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

                if (j.isAlive && Input.GetKey("left")) //gauche
                {
                    if (!leftKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x - unite, j.Vitesse.y);
                        leftKeyAlreadyPressed = true;

                        if (direction == 0)
                        {
                            direction = 180;
                            this.transform.localRotation = new Quaternion(0, direction, 0, 0);
                        }
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
            }

            #endregion
            
            transform.position = j.UpdatePositionJoueur();
            
            #region Etats
            if (j.etats[Joueur.knocked].actif)
            {
                j.position = new Vector3(j.position.x+0.15f*directionProj,j.position.y,j.position.z);
            }
            if (j.position.y > demiHauteur)
            {
                j.etats[Joueur.flying].Timer = 2;
            }
            foreach (var etat in j.etats)
            {
                etat.update();
            }
            #endregion
            
        }
    }
}