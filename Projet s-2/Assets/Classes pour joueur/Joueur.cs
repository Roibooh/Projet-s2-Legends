﻿using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
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
        public class Controle
        {
            protected internal bool upKeyAlreadyPressed = false;
            protected internal bool leftKeyAlreadyPressed = false;
            protected internal bool rigthKeyAlreadyPressed = false;
            protected internal bool downKeyAlreadyPressed = false;
            protected internal bool isShooting = false;
            protected internal float unite;

            public const int Left = 0;
            public const int Right = 1;
            public const int Up = 2;
            public const int Down = 3;
            public const int Hit = 4;
            public const int HitUp = 5;
            public const int Projectile = 6;

            public const int AnimHit = 0;
            public const int Kick = 1;
            public const int AnimHitDown = 2;
            public const int AnimJump = 4;
            public const int AnimFlyingUp = 5;
            public const int AnimFlyingDown= 6;
            public const int AnimLowkick = 7;
            public const int AnimLand = 8;
            public const int AnimBlocking = 9;
            public const int AnimWalking = 10;
            public const int AnimGetHit = 11;
            public const int AnimCrouching = 12;
            public const int AnimCrouched = 13;
            public const int AnimDecrouch = 14;
            public const int AnimMort = 15;
            public  Controle(float unite)
            {
                this.unite = unite;
            }
        }
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
        protected internal const int blocked = 6;
        protected internal const int decrouching = 7;

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
            etats = new Etats[]{new Etats(),new Etats(),new Etats(),new Etats(),new Etats(), new Etats(),new Etats(),new Etats()};
        }
        
        #endregion

        #region Methodes

        protected internal void estAttaque(Animator anim, Personnages.Personnages.Personnage p,int degats = 0, float dureeInv = 0.5f)//durée en sec
        {
            if (!etats[invincibility].actif)
            {
                this.etats[invincibility].setTimer(dureeInv);
                Pv -= degats;
                anim.Play(p.anim[Controle.AnimGetHit]);
            }
        }

        protected internal static (Controle c, Joueur j) keyHandeler(Controle c, Joueur j, Animator anim, Personnages.Personnages.Personnage p)
        {    
            if (Input.GetKey(p.keys[Controle.Up]) && j.nbSauts > 0 && j.isAlive && !j.etats[Joueur.stunned].actif) //saut
            {
                if (!c.upKeyAlreadyPressed)
                {
                    anim.Play(p.anim[Controle.AnimJump]);
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

            
            if (Input.GetKey(p.keys[Controle.Down]) && j.isAlive && !j.etats[Joueur.stunned].actif) //fastfall
            { 
                c.downKeyAlreadyPressed = true;
                {
                    if (j.Vitesse.y - c.unite * 2 > -j.vitessemax*2)
                    {
                        j.Vitesse = new Vector2(j.Vitesse.x, j.Vitesse.y - c.unite * 2);
                    }
                }
                if (!c.downKeyAlreadyPressed && !j.etats[Joueur.flying].actif) // accroupi
                {
                    if (!j.etats[Joueur.crouched].actif && !j.etats[Joueur.attacking].actif)
                    {
                        anim.Play(p.anim[Controle.AnimCrouching]);
                        j.etats[Joueur.crouched].setTimer(Time.fixedDeltaTime);
                    }
                }
                else if(c.downKeyAlreadyPressed && !j.etats[Joueur.flying].actif && !j.etats[Joueur.attacking].actif)
                {
                    j.etats[Joueur.crouched].setTimer(Time.fixedDeltaTime);
                }
            }
            else
            {
                if (c.downKeyAlreadyPressed) // Reprendre forme normale
                {
                    c.downKeyAlreadyPressed = false;
                    if (!j.etats[Joueur.attacking].actif)
                    {
                        j.etats[Joueur.crouched].timer = 0;
                        j.etats[decrouching].setTimer(Time.fixedDeltaTime*4);
                    }
                }
            }
            if (!c.downKeyAlreadyPressed && !Input.GetKey(p.keys[Controle.Down]) && j.etats[Joueur.decrouching].actif)
            {
                anim.Play(p.anim[Controle.AnimDecrouch]);
            }

            if (Input.GetKey(p.keys[Controle.Right]) && j.isAlive && !j.etats[Joueur.stunned].actif && j.isAlive && !j.etats[Joueur.stunned].actif) //droite
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
                if (!j.etats[Joueur.flying].actif&& !j.etats[crouched].actif)
                {
                    anim.Play(p.anim[Controle.AnimWalking]);
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

            if (Input.GetKey(p.keys[Controle.Left]) && j.isAlive && !j.etats[Joueur.stunned].actif) //gauche
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

                if (!j.etats[Joueur.flying].actif && !j.etats[crouched].actif)
                {
                    anim.Play(p.anim[Controle.AnimWalking]);
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
            
            if (Input.GetKey((p.keys[Controle.Projectile])) && !j.etats[Joueur.attacking].actif && !j.etats[Joueur.blocked].actif && j.isAlive && !j.etats[Joueur.stunned].actif && !j.etats[Joueur.crouched].actif)
            {
                
                j.etats[Joueur.blocked].setTimer(1f);
                j.etats[Joueur.invincibility].setTimer(0.5f);
                anim.Play(p.anim[Controle.AnimBlocking]);
                j.etats[Joueur.stunned].setTimer (0.5f);
            }
            if (Input.GetKey(p.keys[Controle.Hit])&& !j.etats[Joueur.attacking].actif && j.isAlive && !j.etats[Joueur.stunned].actif && !j.etats[Joueur.crouched].actif) //Attaque
            {
                anim.Play(p.anim[Controle.AnimHit]);
                j.etats[Joueur.attacking].setTimer (0.4f);
                j.etats[Joueur.stunned].setTimer (0.5f);
            }
            if(Input.GetKey(p.keys[Controle.HitUp])&& !j.etats[Joueur.attacking].actif&& j.isAlive && !j.etats[Joueur.stunned].actif&& j.etats[crouched].actif)
            {
                j.etats[Joueur.crouched].timer = 0;
                j.etats[Joueur.crouched].actif = false;
                j.etats[Joueur.attacking].setTimer (0.4f);
                anim.Play(p.anim[Controle.AnimLowkick]);
                j.etats[Joueur.stunned].setTimer (0.5f);
            }
            else if (Input.GetKey(p.keys[Controle.HitUp])&& !j.etats[Joueur.attacking].actif && j.isAlive && !j.etats[Joueur.stunned].actif && !j.etats[Joueur.crouched].actif) //Attaque Haut
            {
                anim.Play(p.anim[Controle.Kick]);// change en kick
                j.etats[Joueur.attacking].setTimer (0.4f);
                j.etats[Joueur.stunned].setTimer (0.5f);
            }
            return (c,j);
        }

        protected internal static Joueur etatHandler(Joueur j, Personnages.Personnages.Personnage p,Animator anim)
        {
            if (j.etats[Joueur.knocked].actif)
            {
                j.position = new Vector3(j.position.x+0.15f*j.directionProj,j.position.y,j.position.z);
            }
            if (j.etats[Joueur.flying].actif && j.Vitesse.y>0)
            {
                
            }
            else if (j.etats[Joueur.crouched].actif)
            {
                anim.Play(p.anim[Controle.AnimCrouched]);
            }
            else if (j.etats[Joueur.flying].actif && j.Vitesse.y<0 && j.isAlive && !j.etats[attacking].actif)
            {
                anim.Play(p.anim[Controle.AnimFlyingDown]);
            }
            if (j.position.y > j.demiHauteur && j.isAlive)
            {
                j.etats[Joueur.flying].setTimer(Time.fixedDeltaTime);
            }

            if (!j.isAlive)
            {
                anim.Play(p.anim[Controle.AnimMort]);
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