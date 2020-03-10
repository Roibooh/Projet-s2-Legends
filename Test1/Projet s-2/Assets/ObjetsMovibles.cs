using System;
using UnityEngine;

namespace Objets
{
    public abstract class ObjetsMovibles : Objets
    {
        #region Attributs
        private Vector2 vitesse;
        private float vitessemax;
        public Vector2 Vitesse
        {
            get => vitesse;
            private set 
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
        public Vector2 Acceleration
        {
            get => acceleration;
            private set => acceleration = 
                new Vector2(value.x/masse,value.y/masse);
        }
        #endregion
        
        #region Constructeur
        public ObjetsMovibles(Vector3 position, float demiHauteur,float demiLargeur, float masse, float vitessemax = (float)0.5, float vitesseX = 0, float vitesseY = 0, float accelerationX = 0, float accelerationY = 0):base(position,demiHauteur,demiLargeur)
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
            Vitesse = new Vector2(0, vitesse.y - (float)0.005);
        }

        protected internal void Accelere()//applique acceleration
        {
            Vitesse = new Vector2(vitesse.x + acceleration.x,vitesse.y + acceleration.y);
        }

        protected internal Vector2 UpdatePositionObjetMovible()
        {
            Tombe();
            Accelere();
            Deplace();
            //Collision();
            return position;
        }
        #endregion
    }
}