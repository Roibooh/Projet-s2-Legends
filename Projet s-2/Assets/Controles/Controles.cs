using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

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
        private Transform attackHit;
        protected internal Joueur j;
        protected internal int directionProj = 0;
        private Animator anim;


        //Ici on va rajouter les états, pour savoir on peut faire quoi dans chaque état, par exemple pour les attaques
         // Start is called before the first frame update
        void Start()
        {
            attackHit = GetComponentInChildren<Transform>(); 
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

            if (j.isAlive)
            {
                if (Input.GetKey("[2]") && !j.etats[2].actif && !j.etats[5].actif) 
                {
                    anim.Play("Hitup");
                    j.etats[5].timer = 45;
                }
                
                if (Input.GetKey("up") && j.nbSauts > 0) // haut
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


                if (Input.GetKey("down")) //bas
                {

                    if (j.Vitesse.y < 0)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - unite * 2);
                    }

                    if (!downKeyAlreadyPressed && !j.etats[3].actif) // accroupi
                    {
                        j.demiHauteur /= 2;
                        j.position.y -= j.demiHauteur;
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2);
                        downKeyAlreadyPressed = true;
                        j.etats[3].timer = 2;
                    }
                    else
                    {
                        if (Input.GetKey("[1]") && j.etats[3].actif && !j.etats[5].actif) //bas
                        {
                            anim.Play("Spike");
                            j.etats[5].timer = 45;
                        }
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

                if (Input.GetKey("right")) //droite
                {
                    if (Input.GetKey("[1]") && !j.etats[2].actif && !j.etats[5].actif)
                    {
                        anim.Play("Hit");
                        j.etats[5].timer = 45;
                    }
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

                if (Input.GetKey("left")) //gauche
                {
                    if (Input.GetKey("[1]") && !j.etats[2].actif && !j.etats[5].actif)
                    {
                        anim.Play("Hit");
                        j.etats[5].timer = 45;
                    }
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

            if (j.etats[2].actif)
            {
                j.position = new Vector3(j.position.x+0.15f*directionProj,j.position.y,j.position.z);
            }

            foreach (var etat in j.etats)
            {
                etat.update();
            }

            if (j.position.y > demiHauteur)
            {
                j.etats[3].timer = 2;
            }
            #endregion
            
        }
    }
}