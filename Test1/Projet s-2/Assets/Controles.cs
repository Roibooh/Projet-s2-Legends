using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objets
{
    public class Controles : MonoBehaviour
    {
        private bool upKeyAlreadyPressed;
        private bool leftKeyAlreadyPressed;
        private bool rigthKeyAlreadyPressed;
        private bool downKeyAlreadyPressed;
        private float unite = (float)1;//move speed de joueur a importer TODO
        
        private Joueur j;
        // Start is called before the first frame update
        void Start()
        {
            j = new Joueur("test",100,transform.position,20,20,1);
            upKeyAlreadyPressed = false;
            leftKeyAlreadyPressed = false;
            rigthKeyAlreadyPressed = false;
            downKeyAlreadyPressed = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("up"))
            {
                if (!upKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y+unite);
                    upKeyAlreadyPressed = true;
                }
            } 
            else
            {
                if (upKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y-unite);
                    upKeyAlreadyPressed = false;
                }

            } //haut
            
            if (Input.GetKey("down"))
            {
                if (!downKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y-unite);
                    downKeyAlreadyPressed = true;
                }
            }
            else
            {
                if (downKeyAlreadyPressed)
                {
                    j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y + unite);
                    downKeyAlreadyPressed = false;
                }
            }//bas
            
            if (Input.GetKey("right"))
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
                    j.Vitesse = new Vector2(j.Vitesse.x-unite, j.Vitesse.y);
                    rigthKeyAlreadyPressed = false;
                }
            }//droite
            
            if (Input.GetKey("left"))
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
                    j.Vitesse = new Vector2(j.Vitesse.x+unite, j.Vitesse.y);
                    leftKeyAlreadyPressed = false;
                }
            }//gauche

            transform.position = j.UpdatePositionJoueur();
            
        }
    }
}