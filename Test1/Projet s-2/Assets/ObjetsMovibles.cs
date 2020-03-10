using System;
using UnityEngine;

namespace Objets
{
    public  class ObjetsMovibles : Objets
    {
        #region Attributs
        private float vitessemax;
        
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

                if (value.y >= this.vitessemax)
                {
                    this.vitesse.y = this.vitessemax;
                    this.acceleration.y = 0;
                }

                else if (value.y <= -vitessemax)
                {
                    vitesse.y = -vitessemax;
                    acceleration.y = 0;
                }
                else
                {
                    this.vitesse.y = value.y;
                }
                
            }
        }
       
        private Vector2 acceleration;
        private float masse;
        /*public Vector2 Acceleration
        {
            get => acceleration;
            private set => acceleration = 
                new Vector2(value.x/masse,value.y/masse);
        }*/
        #endregion
        
        #region Constructeur
        public ObjetsMovibles(Vector3 position, float demiHauteur=1,float demiLargeur=1, float masse =1 , float vitessemax = (float)0.1, float vitesseX = 0, float vitesseY = 0, float accelerationX = 0, float accelerationY = 0):base(position,demiHauteur,demiLargeur)
        {
            this.vitesse = new Vector2(vitesseX,vitesseY);
            this.acceleration = new Vector2(accelerationX, accelerationY);
            this.masse = masse;
            this.vitessemax = vitessemax;
        }
        #endregion
        
        #region Methodes
        
        protected internal void ChgAccel(float x = 0,float y = 0)
        {
            acceleration = new Vector2(acceleration.x + x/masse, acceleration.y + y/masse);
        }
        
        protected internal void Deplace() //Deplace de X et Y
        {
            position.x += vitesse.x;
            position.y += vitesse.y;
        }

        protected internal void Tombe()
        {
            Vitesse = new Vector2(vitesse.x, vitesse.y - (float)0.0005*masse);
        }

        protected internal void Accelere()//applique acceleration
        {
            Vitesse = new Vector2(vitesse.x + acceleration.x,vitesse.y + acceleration.y);
        }
        
        protected internal void Collision(Objets obj2)
        {
            if (CollisionX(obj2)&&CollisionY(obj2))
            {
                if (obj2.position.x - obj2.demiLargeur- this.position.x + this.demiLargeur >= 0)// check gauche
                {
                    this.position.x = obj2.position.x - this.demiLargeur - obj2.demiLargeur;
                    this.vitesse.x = 0;
                    this.acceleration.x = 0;
                }
                else if (obj2.position.x + obj2.demiLargeur - this.position.x + this.demiLargeur < 0)// check droit
                {
                    this.position.x = obj2.position.x + this.demiLargeur + obj2.demiLargeur;
                    this.vitesse.x = 0;
                    this.acceleration.x = 0;
                }
                if (obj2.position.y - obj2.demiHauteur - this.position.y + this.demiHauteur >= 0) // check bas 
                {
                    this.position.y = obj2.position.y - obj2.demiHauteur - this.demiHauteur;
                    this.vitesse.y = 0;
                    this.acceleration.y = 0;
                }
                else if (obj2.position.y + obj2.demiHauteur - this.position.y - this.demiHauteur < 0) // check haut
                {
                    this.position.y = obj2.demiHauteur + obj2.position.y + this.demiHauteur;
                    this.vitesse.y = 0;
                    this.acceleration.y = 0;
                }
            }
        }

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