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
        private float unite = (float)0.15;//move speed de joueur a importer TODO
        private Joueur j;
        // Start is called before the first frame update
        void Start()
        {
            j = new Joueur("test",100,transform.position,1,1,3,3);
            upKeyAlreadyPressed = false; 
            leftKeyAlreadyPressed = false;
            rigthKeyAlreadyPressed = false;
            downKeyAlreadyPressed = false;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 e = new Vector3(0,(float)-0.5,0);
            ObjetsMovibles o = new ObjetsMovibles(e, (float)0.5, 50);
            if (Input.GetKey("e"))
            {
                j.Knockback((float)0.1, (float)0.05,1);
            }
            if (Input.GetKey("up") && j.nbSauts > 0)// haut
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

                if (j.CollisionY(o))
                {
                    j.nbSauts = j.nbSautsMax;
                }
            }
            if (Input.GetKey("down")) //bas
            {
                if (!downKeyAlreadyPressed) // accroupi and fastfall
                {
                    j.demiHauteur /= 2;
                    j.position.y -= j.demiHauteur;
                    transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y/2);
                    if (j.Vitesse.y < 0)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - unite * 2);
                    }
                    downKeyAlreadyPressed = true;
                }
            }
            else
            {
                if (downKeyAlreadyPressed)
                {
                    j.position.y += j.demiHauteur;
                    j.demiHauteur *= 2;
                    transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*2);
                    downKeyAlreadyPressed = false;
                }
            }
            
            if (Input.GetKey("right"))//droite
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
            if (Input.GetKey("left"))//gauche
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
            j.Collision(o);
        }
    }
}