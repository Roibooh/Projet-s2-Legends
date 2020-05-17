using System;
using System.Diagnostics.Tracing;
using UnityEngine;
/* Author : Julien Lung Yut Fong et Guillaume MERCIER
 *
 * Classe des joueurs
 */
namespace Objets
{
    public class Joueur : ObjetsMovibles
    {
        #region Attributs

        private string nom;
        public int pv;
        private int pvMax;
        protected internal bool isAlive;
        protected internal int nbSauts;
        protected internal int nbSautsMax;
        protected internal Etats[] etats;
        protected internal const int invincibility = 0;
        protected internal const int stunned = 1;
        protected internal const int knocked = 2;
        protected internal const int crouched = 3;
        protected internal const int flying = 4;
        protected internal const int attacking = 5;

        public class Controle
        {
            protected internal bool upKeyAlreadyPressed = false;
            protected internal bool leftKeyAlreadyPressed = false;
            protected internal bool rigthKeyAlreadyPressed = false;
            protected internal bool downKeyAlreadyPressed = false;
            protected internal float unite;

            protected internal string[] keyList;
            public const int Hit = 0;
            public const int HitUp = 1;
            public const int Left = 2;
            public const int Right = 3;
            public const int Up = 4;
            public const int Down = 5;
            public Controle(float unite, string[] keyList)
            {
                this.unite = unite;
                this.keyList = keyList;
            }
        }
        
        public int Pv
        {
            get => pv;
            private set
            {
                if (value > pvMax)
                {
                    pv = pvMax;
                }
                else if(value < 1)
                {
                    pv = 0;
                    isAlive = false;
                }
                else
                {
                    pv = value;
                }
            }
        }

        #endregion

        #region Constructeur

        public Joueur(string nom, int pv,Vector3 position, float demiHauteur, float demiLargeur, int masse, Vector3 localscale, Quaternion localrotate, int nbSauts = 1) : base(position, localscale,localrotate,demiHauteur,demiLargeur,masse)
        {
            this.isAlive = true;
            this.nom = nom;
            this.pv = pv;
            this.pvMax = pv;
            this.nbSauts = nbSauts;
            this.nbSautsMax = nbSauts;
            
            etats = new Etats[]{new Etats(),new Etats(),new Etats(),new Etats(),new Etats(), new Etats(), };
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(int degats = 0, float dureeInv = 0.5f)//durée en sec
        {
            if (!etats[invincibility].actif)
            {
                etats[Joueur.stunned].setTimer(2);
                Pv -= degats;
                etats[invincibility].setTimer (5);
            }
        }

        protected internal static (Controle c, Joueur j) keyHandeler(Controle c, Joueur j, Animator anim)
        {
            if (!j.etats[Joueur.stunned].actif)
            {
                if (Input.GetKey(c.keyList[Controle.Hit])&& !j.etats[Joueur.attacking].actif) //Attaque
                {
                    anim.Play("Hit");
                    j.etats[Joueur.attacking].setTimer (1);
                }
                if (Input.GetKey(c.keyList[Controle.HitUp])&& !j.etats[Joueur.attacking].actif) //Attaque Haut
                {
                    anim.Play("Hitup");
                    j.etats[Joueur.attacking].setTimer (1);
                }
                
                if (j.isAlive && Input.GetKey(c.keyList[Controle.Up]) && j.nbSauts > 0) //saut
                {
                    if (!c.upKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x, c.unite);
                        c.upKeyAlreadyPressed = true;
                    }
                }
                else
                {
                    if (c.upKeyAlreadyPressed)
                    {
                        j.nbSauts--;
                        c.upKeyAlreadyPressed = false;
                    }

                    if (j.position.y <= j.demiHauteur)
                    {
                        j.nbSauts = j.nbSautsMax;
                    }
                }


                if (j.isAlive && Input.GetKey(c.keyList[Controle.Down])) //fastfall
                {
                    if (j.Vitesse.y < 0)
                    {
                        if (j.Vitesse.y - c.unite * 2 > -j.vitessemax*2)
                        {
                            j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - c.unite * 2);
                        }
                    }

                    if (Input.GetKey(c.keyList[Controle.Hit])&& !j.etats[Joueur.attacking].actif && j.etats[Joueur.flying].actif)
                    {
                        anim.Play("Spike");
                        j.etats[Joueur.attacking].setTimer (35);
                    }

                    if (!c.downKeyAlreadyPressed && !j.etats[Joueur.flying].actif) // accroupi
                    {
                        j.demiHauteur /= 2;
                        j.position.y -= j.demiHauteur;
                        j.localscale = new Vector3(j.localscale.x, j.localscale.y / 2);
                        c.downKeyAlreadyPressed = true;
                        j.etats[Joueur.crouched].setTimer (2);
                    }
                }
                else
                {
                    if (c.downKeyAlreadyPressed) // Reprendre forme normale
                    {
                        j.position.y += j.demiHauteur;
                        j.demiHauteur *= 2;
                        j.localscale = new Vector3(j.localscale.x, j.localscale.y * 2);
                        c.downKeyAlreadyPressed = false;
                    }
                }

                if (j.isAlive && Input.GetKey(c.keyList[Controle.Right])) //droite
                {
                    if (!c.rigthKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x + c.unite, j.Vitesse.y);
                        c.rigthKeyAlreadyPressed = true;

                        if (j.direction == 180)
                        {
                            j.direction = 0;
                            j.localrotate = new Quaternion(0, j.direction, 0, 0);
                        }
                    }
                }
                else
                {
                    if (c.rigthKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x - c.unite, j.Vitesse.y);
                        c.rigthKeyAlreadyPressed = false;
                    }
                }

                if (j.isAlive && Input.GetKey(c.keyList[Controle.Left])) //gauche
                {
                    if (!c.leftKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x - c.unite, j.Vitesse.y);
                        c.leftKeyAlreadyPressed = true;

                        if (j.direction == 0)
                        {
                            j.direction = 180;
                            j.localrotate = new Quaternion(0, j.direction, 0, 0);
                        }
                    }
                }
                else
                {
                    if (c.leftKeyAlreadyPressed)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x + c.unite, j.Vitesse.y);
                        c.leftKeyAlreadyPressed = false;
                    }
                }
            }

            return (c,j);
        }

        protected internal Vector2 UpdatePositionJoueur()
        {
            return this.UpdatePositionObjetMovible();
        }
        #endregion
    }
}