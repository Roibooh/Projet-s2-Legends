using System;
using UnityEngine;

namespace Objets
{
    public abstract class ObjetsMovibles : Objets
    {
        #region Attributs
        private Vector2 vitesse;
        private Vector2 acceleration;
        private float masse;
        public Vector2 Acceleration
        {
            get => acceleration;
            protected set => acceleration = 
                new Vector2(value.x/masse,value.y/masse);
        }
        #endregion
        #region Constructeur
        public ObjetsMovibles(Vector3 position, float hauteur,float largeur, float masse, float vitesseX = 0, float vitesseY = 0, float accelerationX = 0, float accelerationY = 0):base(position,hauteur,largeur)
        {
            this.vitesse = new Vector2(vitesseX,vitesseY);
            this.acceleration = new Vector2(accelerationX, accelerationY);
            this.masse = masse;
        }
        #endregion
        #region Methodes
        
        protected internal void ChgAccel(float x = 0,float y = 0)
        {
            acceleration += new Vector2(x/masse,y/masse);
        }
        
        protected internal void Deplace() //Deplace de X et Y
        {
            position.x += vitesse.x;
            position.y += vitesse.y;
        }

        protected internal void Tombe()
        {
            vitesse.y -= masse * (float) 0.05;
        }

        protected internal void Accelere()//applique acceleration
        {
            vitesse.x += acceleration.x;
            vitesse.y += acceleration.y;
        }

        protected internal void UpdateObjetMovible()
        {
            Tombe();
            Accelere();
            Deplace();
        }
        #endregion
    }
}