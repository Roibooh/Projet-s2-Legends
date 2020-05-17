﻿using System;
using UnityEngine;
/* Author : Julien Lung Yut Fong et Guillaume MERCIER
 *
 * Classe des objets movibles
 */
namespace Objets
{
    public  class ObjetsMovibles : Objets
    {
        #region Attributs

        internal float vitessemax;
        protected internal int direction = 0; // 180 = gauche
        protected internal int directionProj = 0;
        
        private Vector2 vitesse;
        public Vector2 Vitesse
        {
            get => vitesse;
            protected internal set 
            {
                
                if (value.x >= this.vitessemax)
                {
                    this.vitesse.x = this.vitessemax;
                    this.acceleration.x = 0;
                    
                }
                
                else if (value.x <= -vitessemax)
                {
                    vitesse.x = -vitessemax;
                    acceleration.x = 0;
                }
                else
                {
                    vitesse.x = value.x;
                }

                if (value.y >= this.vitesseMaxY)
                {
                    this.vitesse.y = this.vitesseMaxY;
                    this.acceleration.y = 0;
                }

                else if (value.y <= -vitesseMaxY)
                {
                    vitesse.y = -vitesseMaxY;
                    acceleration.y = 0;
                }
                else
                {
                    this.vitesse.y = value.y;
                }
                
            }
        }
       
        private Vector2 acceleration;
        protected internal float masse;
        /*public Vector2 Acceleration
        {
            get => acceleration;
            private set => acceleration = 
                new Vector2(value.x/masse,value.y/masse);
        }*/

        internal float vitesseMaxY;

        protected internal Vector3 Position
        {
        
            set
            {
                position = value;
                if (position.y - demiHauteur < 0)
                {
                    position = new Vector3(position.x,demiHauteur,position.z);
                    /*if (vitesse.y < -1)
                    {
                        vitesse.y = vitesse.y * -0.1f;
                    }*/
                }
            }
        }
        #endregion
        
        #region Constructeur
        public ObjetsMovibles(Vector3 Position, Vector3 localscale, Quaternion localrotate, float demiHauteur=1,float demiLargeur=1, float masse =1 , float vitesseX = 0, float vitesseY = 0, float vitessemax = (float) 0.6,float accelerationX = 0, float accelerationY = 0):base(Position,demiHauteur,demiLargeur, localscale, localrotate)
        {
            this.vitesse = new Vector2(vitesseX,vitesseY);
            this.acceleration = new Vector2(accelerationX, accelerationY);
            this.masse = masse;
            this.vitessemax = vitessemax;
            this.vitesseMaxY = vitessemax * 5;
        }
        #endregion
        
        #region Methodes
        
        protected internal void ChgAccel(float x = 0,float y = 0)
        {
            acceleration = new Vector2(acceleration.x + x/masse, acceleration.y + y/masse);
        }
        
        protected internal void Deplace() //Deplace de X et Y
        {
            Position = new Vector3(position.x + vitesse.x, position.y, position.z);
            position=  new Vector3(position.x, position.y+ vitesse.y, position.z);
        }

        protected internal void Tombe()
        {
            if (vitesse.y - (float) 0.005 * masse > -vitessemax)
            {
                Vitesse = new Vector2(vitesse.x, vitesse.y - (float) 0.005 * masse);
            }
        }

        protected internal void Accelere()//applique acceleration
        {
            Vitesse = new Vector2(vitesse.x + acceleration.x,vitesse.y + acceleration.y);
        }

        protected internal void Knockback(float forceKBx,float forceKBy,int direction) // -1 :gauche 1 :droite
        {
            this.Vitesse = new Vector2(this.Vitesse.x + forceKBx * direction / this.masse, this.Vitesse.y + forceKBy / this.masse);
        }
        
        /*
        protected internal void Collision(Objets obj2)
        {
            if (CollisionX(obj2)&&CollisionY(obj2))
            {
                if (obj2.position.x - obj2.demiLargeur- this.position.x + this.demiLargeur >= 0)// check gauche
                {
                    this.Position = new Vector3(obj2.position.x - this.demiLargeur - obj2.demiLargeur, position.y,position.z);
                    this.vitesse.x = 0;
                    this.acceleration.x = 0;
                }
                else if (obj2.position.x + obj2.demiLargeur - this.position.x + this.demiLargeur < 0)// check droit
                {
                    this.Position = new Vector3(obj2.position.x + this.demiLargeur + obj2.demiLargeur,position.y,position.z);
                    this.vitesse.x = 0;
                    this.acceleration.x = 0;
                }
                if (obj2.position.y - obj2.demiHauteur - this.position.y + this.demiHauteur >= 0) // check bas 
                {
                    this.Position = new Vector3(position.x,obj2.position.y - obj2.demiHauteur - this.demiHauteur,position.z);
                    this.vitesse.y = 0;
                    this.acceleration.y = 0;
                }
                else if (obj2.position.y + obj2.demiHauteur - this.position.y - this.demiHauteur < 0) // check haut
                {
                    this.Position = new Vector3(position.x,obj2.demiHauteur + obj2.position.y + this.demiHauteur,position.z);
                    this.vitesse.y = 0;
                    this.acceleration.y = 0;
                }
            }
        }*/

        protected internal Vector2 UpdatePositionObjetMovible()
        {
            Tombe();
            Accelere();
            Deplace();
            
            return position;
        }
        #endregion
    }
}