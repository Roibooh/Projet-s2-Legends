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
        public ObjetsMovibles(Vector3 position, float poids, float vitesseX = 0, float vitesseY = 0, float accelerationX = 0, float accelerationY = 0):base(position)
        {
            this.vitesse = new Vector2(vitesseX,vitesseY);
            this.acceleration = new Vector2(accelerationX, accelerationY);
            this.masse = poids;
        }
        #endregion
        #region Methodes
        protected internal void Deplace() //Deplace de X et Y
        {
            position.x += vitesse.x;
            position.y += vitesse.y;
        }

        protected internal void ChgAccel(float x,float y)
        {
            acceleration += new Vector2(x/masse,y/masse);
        }

        protected internal void Tombe()
        {
            acceleration.y -= masse * (float)0.1;
        }

        protected internal void Accelere()//applique acceleration
        {
            vitesse.x += acceleration.x;
            vitesse.y += acceleration.y;
        }
        #endregion
    }
}