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
            protected internal bool isShooting = false;
            protected internal float unite;
            
            public const int Hit = 0;
            public const int HitUp = 1;
            public const int Left = 2;
            public const int Right = 3;
            public const int Up = 4;
            public const int Down = 5;
            public const int Projectile = 6;

            public const int AnimHit = 0;
            public const int AnimHitUp = 1;
            public const int AnimHitDown = 2;
            public Controle(float unite)
            {
                this.unite = unite;
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
                this.etats[invincibility].setTimer(dureeInv);
                Pv -= degats;
            }
        }

        protected internal static (Controle c, Joueur j) keyHandeler(Controle c, Joueur j, Animator anim, Personnages.Personnages.Personnage p)
        {
            if (j.isAlive && !j.etats[Joueur.stunned].actif)
            {
                if (Input.GetKey((p.keys[Controle.Projectile])) && !j.etats[Joueur.attacking].actif)
                {
                    //TODO
                }
                
                if (Input.GetKey(p.keys[Controle.Hit])&& !j.etats[Joueur.attacking].actif) //Attaque
                {
                    anim.Play(p.anim[Controle.AnimHit]);
                    j.etats[Joueur.attacking].setTimer (0.5f);
                    
                }
                if (Input.GetKey(p.keys[Controle.HitUp])&& !j.etats[Joueur.attacking].actif) //Attaque Haut
                {
                    anim.Play(p.anim[Controle.AnimHitUp]);
                    j.etats[Joueur.attacking].setTimer (0.5f);
                }
                
                if (Input.GetKey(p.keys[Controle.Up]) && j.nbSauts > 0) //saut
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


                if (Input.GetKey(p.keys[Controle.Down])) //fastfall
                {
                    if (j.Vitesse.y < 0)
                    {
                        if (j.Vitesse.y - c.unite * 2 > -j.vitessemax*2)
                        {
                            j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - c.unite * 2);
                        }
                    }

                    if (Input.GetKey(p.keys[Controle.Hit])&& !j.etats[Joueur.attacking].actif && j.etats[Joueur.flying].actif)
                    {
                        anim.Play(p.anim[Controle.AnimHitDown]);
                        j.etats[Joueur.attacking].setTimer (1);
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

                if (Input.GetKey(p.keys[Controle.Right])) //droite
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

                if (Input.GetKey(p.keys[Controle.Left])) //gauche
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

        protected internal static Joueur etatHandler(Joueur j)
        {
            if (j.etats[Joueur.knocked].actif)
            {
                j.position = new Vector3(j.position.x+0.15f*j.directionProj,j.position.y,j.position.z);
            }
            if (j.position.y > j.demiHauteur)
            {
                j.etats[Joueur.flying].setTimer(Time.fixedDeltaTime*2);
            }

            foreach (var etat in j.etats)
            {
                etat.update();
            }

            return j;
        }
        protected internal Vector2 UpdatePositionJoueur()
        {
            return this.UpdatePositionObjetMovible();
        }
        #endregion
    }
}